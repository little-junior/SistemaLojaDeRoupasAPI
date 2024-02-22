using Microsoft.AspNetCore.Mvc.Filters;

namespace SistemaLojaDeRoupas.API.Filters
{
    public class LogResultFilter : IResultFilter
    {
        private readonly ILogger<LogResultFilter> _logger;

        public LogResultFilter(ILogger<LogResultFilter> logger)
        {
            _logger = logger;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var metodo = context.HttpContext.Request.Method;
            if (context.HttpContext.Response.StatusCode <= 399)
            {
                _logger.LogInformation($"{metodo} responded with success");
                return;
            }

            _logger.LogCritical("Algo deu errado.");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var metodo = context.HttpContext.Request.Method;
            if (context.HttpContext.Response.StatusCode <= 399)
            {
                _logger.LogInformation($"{metodo} requested");
                return;
            }

            _logger.LogCritical("Algo deu errado.");
        }
    }
}
