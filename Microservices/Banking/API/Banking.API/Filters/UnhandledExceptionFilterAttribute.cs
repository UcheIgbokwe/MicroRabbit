using System;
using System.Collections.Generic;
using Banking.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Banking.API.Filters
{
    public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<UnhandledExceptionFilterAttribute> _logger;
        public UnhandledExceptionFilterAttribute(ILogger<UnhandledExceptionFilterAttribute> logger)
        {
            _logger = logger;
            
        }
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                context.Result = new JsonResult(context.Exception.ToApiResponse())
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
                _logger.LogError("Unhandled exception occurred while executing request: {ex}", context.Exception);
            }
        }
    }

    public static class ExceptionExtensions
    {
        public static ApiResponse<object> ToApiResponse(this Exception exception)
        {
            return new ApiResponse<object>(false, "Internal Server Error", new List<string> { exception.Message });
        }
    }
}