using BookStore.DTOs.Author;

namespace BookStore.DTOs.Book
{
    public class BookDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public int? AuthorId { get; set; }
        public AuthorDto? Author { get; set; }
    }
}
