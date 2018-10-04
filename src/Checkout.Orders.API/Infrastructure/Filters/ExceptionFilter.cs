using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Checkout.Orders.API.Infrastructure.Filters
{
    public class ApiExceptionFilterAttribute : TypeFilterAttribute
    {
        public ApiExceptionFilterAttribute() : base(typeof
            (ApiExceptionFilterAttributeImpl))
        {
        }

        public class ApiExceptionFilterAttributeImpl : IExceptionFilter
        {
            private readonly ILogger<ApiExceptionFilterAttributeImpl> _logger;

            public ApiExceptionFilterAttributeImpl(ILogger<ApiExceptionFilterAttributeImpl> logger)
            {
                _logger = logger;
            }

            public void OnException(ExceptionContext context)
            {
                _logger.LogError(context.Exception.Message);
                var response = new ErrorResponse
                    {Message = "An error occurred.", ExceptionMessage = context.Exception.Message};
                context.Result = new JsonResult(response);
            }
        }
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
