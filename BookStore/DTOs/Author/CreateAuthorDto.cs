namespace BookStore.DTOs.Author
{
    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public List<int>? BooksIds { get; set; } = new();
    }
}
