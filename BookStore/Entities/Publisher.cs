namespace BookStore.Entities
{
    public class Publisher : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public ICollection<AuthorPublisher> AuthorPublishers { get; set; } = new List<AuthorPublisher>();
    }
}
