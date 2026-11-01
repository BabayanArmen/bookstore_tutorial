using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configutations
{
    public class AuthorPublisherConfigurations : IEntityTypeConfiguration<AuthorPublisher>
    {
        public void Configure(EntityTypeBuilder<AuthorPublisher> builder)
        {
            builder.HasKey(ap => new { ap.AuthorId, ap.PublisherId });

            builder.HasOne(ap => ap.Author)
                .WithMany(a => a.AuthorPublishers)
                .HasForeignKey(ap => ap.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ap => ap.Publisher)
                .WithMany(p => p.AuthorPiblishers)
                .HasForeignKey(ap => ap.PublisherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
