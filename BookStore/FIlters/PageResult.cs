namespace BookStore.FIlters
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; } = new();

        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
