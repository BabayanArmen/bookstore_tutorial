namespace BookStore.Models
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public int Status { get; set; }
        public string? ErrorMessage { get; set; } = string.Empty;
        public PageInfo? PageInfo { get; set; }
    }
}
