using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using PollManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PollManager.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception.Message);

            var result = new ObjectResult(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier,
                ErrorMessage = context.Exception.Message
            });
            result.StatusCode = 500;

            context.ExceptionHandled = true;
            context.Result = result;
        }
    }
}
