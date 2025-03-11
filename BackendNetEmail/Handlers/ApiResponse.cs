using System.Net;

namespace BackendNetEmail.Handlers
{
    public class ApiResponse
    {
        private HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        private string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
