using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Publisher> Publisher => Set<Publisher>();
        public DbSet<AuthorPublisher> AuthorPublishers => Set<AuthorPublisher>();

        // This method automaticly sets CreateDate, ModifyDate, IsDeleted default values
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            var now = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = now;
                    entry.Entity.ModifyDate = now;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifyDate = now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.ModifyDate = now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        // For all get request returns only entities with IsDeleted == false
        // To get deleted items, in query linq need to add .IgnoreQueryFilters()
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    continue;
                }

                var parameter = Expression.Parameter(entityType.ClrType, "e");

                var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));

                var condition = Expression.Equal(property, Expression.Constant(false));

                var lambda = Expression.Lambda(condition, parameter);

                modelBuilder.Entity(entityType.ClrType)
                    .HasQueryFilter(lambda);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
