namespace BookStore.Models
{
    public class PageResult<T>
    {
        public T? Data { get; set; }

        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
