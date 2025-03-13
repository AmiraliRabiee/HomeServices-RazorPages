using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeServices.Endpoints.WebApi.WebFramework
{
    public class ApiKeyAuthenticationFilter : IActionFilter
    {
        private const string ValidApiKey = "123";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.TryGetValue("apiKey", out var apiKey))
            {
                context.Result = new UnauthorizedResult(); 
                return;
            }
            if (apiKey?.ToString() != ValidApiKey)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
