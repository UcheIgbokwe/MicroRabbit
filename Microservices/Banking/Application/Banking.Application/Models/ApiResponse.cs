using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Application.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse(bool success, string message, List<string> errors)
        {
            Message = message;
            Success = success;
            Errors = errors;
        }

        public ApiResponse(object data, string message)
        {
            Data = data;
            Success = true;
            Message = message;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }

        public static ApiResponse<T> FromData(object data, string message)
        {
            return new ApiResponse<T>(data, message);
        }

        public static ApiResponse<T> WithErrors(string message, List<string> errors)
        {
            return new ApiResponse<T>(false, message, errors);
        }

        public static ApiResponse<T> WithError(string message)
        {
            return new ApiResponse<T>(false, message, new List<string> { message });
        }
    }
}