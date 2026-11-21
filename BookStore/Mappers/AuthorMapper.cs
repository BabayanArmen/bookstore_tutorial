using BookStore.DTOs.Author;
using BookStore.Entities;

namespace BookStore.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToDto(this Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                CreateDate = author.CreateDate,
                ModifyDate = author.ModifyDate,
                IsDeleted = author.IsDeleted,
                Name = author.Name,

                BookIds = author.Books
                    .Select(b => b.Id)
                    .ToList(),

                PublisherIds = author.AuthorPublishers
                    .Select(ap => ap.PublisherId)
                    .ToList()
            };
        }

        public static Author CreateToEntity(this CreateAuthorDto dto)
        {
            return new Author
            {
                Name = dto.Name
            };
        }
    }
}
