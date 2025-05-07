using App.Domain.Core.Exceptions;

namespace HomeServices_RazorPage.Middleware
{
    public class NotFoundHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException)
            {
                context.Response.Redirect("/Errors/index");
            }
        }
    }

}
