namespace BookStore.Models
{
    public class Result
    {
        public static Response<T> Success<T>(T? data, PageInfo? pageInfo = null)
        {
            return new Response<T>
            {
                Data = data,
                IsSuccess = true,
                Status = 1,
                ErrorMessage = null,
                PageInfo = pageInfo
            };
        }

        public static Response<T> Fail<T>(string? message, int status = 0)
        {
            return new Response<T>
            {
                Data = default,
                IsSuccess = false,
                Status = status,
                ErrorMessage = message,
                PageInfo = null
            };
        }
    }
}
