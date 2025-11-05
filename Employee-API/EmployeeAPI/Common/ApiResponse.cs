namespace Common
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string Details { get; set; }

        public ApiResponse(int statusCode, string message, T data = default, string details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Details = details;
        }
    }

}
