namespace BookStore.Models
{
    public class PageResult<T>
    {
        public List<T>? Data { get; set; }
        public PageInfo? PageInfo { get; set; }
    }
}
