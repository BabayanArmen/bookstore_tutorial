using BookStore.DTOs.Book;

namespace BookStore.DTOs.Author
{
    public class AuthorDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public List<BookDto>? Books { get; set; } = new();
    }
}
