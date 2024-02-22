using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaLojaDeRoupas.API.ResponseDTOs;
using SistemaLojaDeRoupas.API.CustomExceptions;

namespace SistemaLojaDeRoupas.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exceptionResponse = new ExceptionResponse()
            {
                SystemLog = "An exception was thrown by the system",
                Message = context.Exception.Message
            };

            if (context.Exception is CustomException customException)
                context.HttpContext.Response.StatusCode = customException.StatusCode;
            else
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new JsonResult(exceptionResponse) { };

            _logger.LogError($"ERROR: {context.Exception.Message}");
        }
    }
}
