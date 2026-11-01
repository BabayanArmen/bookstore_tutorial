using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configutations
{
    public class PublisherConfigurations : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder.HasMany(p => p.AuthorPiblishers)
                .WithOne(ap => ap.Publisher)
                .HasForeignKey(ap => ap.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
