namespace BookStore.DTOs.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}
