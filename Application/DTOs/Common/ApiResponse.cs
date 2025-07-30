using System.Collections.Generic;

namespace Application.DTOs.Common
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public ApiResponse() { }

        public ApiResponse(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public ApiResponse(T data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }
    }

}
