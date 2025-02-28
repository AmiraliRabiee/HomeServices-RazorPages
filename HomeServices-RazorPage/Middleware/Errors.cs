namespace HomeServices_RazorPage.Middleware
{
    public class Errors
    {
        public class RoleBasedAccessControlMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly string[] _allowedRoles;

            public RoleBasedAccessControlMiddleware(RequestDelegate next, string[] allowedRoles)
            {
                _next = next;
                _allowedRoles = allowedRoles;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var userRole = context.Session.GetString("UserRole");

                if (string.IsNullOrEmpty(userRole))
                {
                    context.Response.Redirect("/Login");
                    return;
                }

                if (_allowedRoles.Contains(userRole))
                {
                    await _next(context);
                }
                else
                {
                    context.Response.Redirect("/Login"); // or context.Response.StatusCode = 403;
                    return;
                }
            }
        }
    }
}
