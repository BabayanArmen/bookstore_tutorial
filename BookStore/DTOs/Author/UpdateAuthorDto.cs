namespace BookStore.DTOs.Author
{
    public class UpdateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public List<int>? BooksIds { get; set; } = new();
    }
}
