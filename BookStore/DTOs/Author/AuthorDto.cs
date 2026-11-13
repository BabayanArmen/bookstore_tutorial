using BookStore.DTOs.Book;

namespace BookStore.DTOs.Author
{
    public class AuthorDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public List<int>? BookIds { get; set; } = new();
        public List<int>? PublisherIds { get; set; } = new();
    }
}
