namespace BookStore.DTOs.Publisher
{
    public class UpdatePublisherDto
    {
        public string Title { get; set; } = string.Empty;
        public List<int>? AuthorIds { get; set; } = new();
    }
}
