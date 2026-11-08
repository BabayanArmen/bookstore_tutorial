using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configutations
{
    public class AuthorPublisherConfigurations : IEntityTypeConfiguration<AuthorPublisher>
    {
        public void Configure(EntityTypeBuilder<AuthorPublisher> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(ap => new { ap.AuthorId, ap.PublisherId }).IsUnique();

            builder.HasOne(ap => ap.Author)
                .WithMany(a => a.AuthorPublishers)
                .HasForeignKey(ap => ap.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ap => ap.Publisher)
                .WithMany(p => p.AuthorPublishers)
                .HasForeignKey(ap => ap.PublisherId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
