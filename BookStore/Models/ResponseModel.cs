namespace BookStore.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public int Status { get; set; }
        public string? ErrorMessage { get; set; }
        public PageInfo? PageInfo { get; set; }
    }
}
