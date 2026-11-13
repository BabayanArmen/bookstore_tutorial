namespace BookStore.DTOs.Author
{
    public class UpdateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public List<int>? BookIds { get; set; } = new();
        public List<int>? PublisherIds { get; set; } = new();
    }
}
