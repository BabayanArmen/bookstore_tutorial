using BookStore.DTOs.Book;
using BookStore.Entities;

namespace BookStore.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                CreateDate = book.CreateDate,
                ModifyDate = book.ModifyDate,
                IsDeleted = book.IsDeleted,

                Title = book.Title,

                Author = book.Author?.ToDto(),
                AuthorId = book.AuthorId,
            };
        }

        public static Book CreateToEntity(this CreateBookDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                AuthorId = dto.AuthorId
            };
        }

        public static void UpdateToEntoty(this Book book, UpdateBookDto dto)
        {
            book.Title = dto.Title;
            book.AuthorId = dto.AuthorId;
        }
    }
}
