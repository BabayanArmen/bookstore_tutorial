using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configutations
{
    public class AuthorConfigurations : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.AuthorPublishers)
                .WithOne(ap => ap.Author)
                .HasForeignKey(ap => ap.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}






//builder.HasOne(b => b.Author)
//    .WithMany(a => a.Books)
//    .HasForeignKey(b => b.AuthorId)
//    .IsRequired()
//    .OnDelete(DeleteBehavior.Cascade);