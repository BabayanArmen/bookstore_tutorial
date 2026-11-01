namespace BookStore.Entities
{
    public class AuthorPublisher
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;
    }
}
