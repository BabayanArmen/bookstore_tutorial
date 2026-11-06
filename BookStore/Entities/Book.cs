namespace BookStore.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }
}
