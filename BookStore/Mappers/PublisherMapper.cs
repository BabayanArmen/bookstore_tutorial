using BookStore.DTOs.Publisher;
using BookStore.Entities;

namespace BookStore.Mappers
{
    public static class PublisherMapper
    {
        public static PublisherDto ToDto(this Publisher publisher)
        {
            return new PublisherDto
            {
                Id = publisher.Id,
                CreateDate = publisher.CreateDate,
                ModifyDate = publisher.ModifyDate,
                IsDeleted = publisher.IsDeleted,

                Title = publisher.Title,

                AuthorIds = publisher.AuthorPublishers
                    .Select(ap => ap.AuthorId)
                    .ToList()
            };
        }

        public static Publisher CreateToEntity(this CreatePublisherDto dto)
        {
            return new Publisher
            {
                Title = dto.Title
            };
        }

        public static void UpdateToEntity(this Publisher publisher, UpdatePublisherDto dto)
        {
            publisher.Title = dto.Title;
        }
    }
}
