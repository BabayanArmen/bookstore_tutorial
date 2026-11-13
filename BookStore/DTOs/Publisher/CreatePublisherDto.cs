namespace BookStore.DTOs.Publisher
{
    public class CreatePublisherDto
    {
        public string Title { get; set; } = string.Empty;
        public List<int>? AuthorIds { get; set; }
    }
}
