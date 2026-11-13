using BookStore.DTOs.Author;

namespace BookStore.DTOs.Publisher
{
    public class PublisherDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public List<int>? AuthorIds { get; set; } = new();
    }
}
