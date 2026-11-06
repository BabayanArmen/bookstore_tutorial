namespace BookStore.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<AuthorPublisher> AuthorPublishers { get; set; } = new List<AuthorPublisher>();
    }
}
