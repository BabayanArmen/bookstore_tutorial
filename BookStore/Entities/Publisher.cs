namespace BookStore.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<AuthorPublisher>? AuthorPiblishers { get; set; } = new List<AuthorPublisher>();
    }
}
