namespace BookStore.DTOs.Author
{
    public class AuthorDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public List<int>? BookIds { get; set; }
        public List<int>? PublisherIds { get; set; }
    }
}
