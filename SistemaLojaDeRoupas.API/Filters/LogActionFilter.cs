using Microsoft.AspNetCore.Mvc.Filters;

namespace SistemaLojaDeRoupas.API.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var metodo = context.HttpContext.Request.Method;

            _logger.LogInformation($"{metodo} começando...");
        }
    }
}
