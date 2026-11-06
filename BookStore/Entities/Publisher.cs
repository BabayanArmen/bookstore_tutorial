namespace BookStore.Entities
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<AuthorPublisher> AuthorPublishers { get; set; } = new List<AuthorPublisher>();
    }
}
