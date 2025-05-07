using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

public class PendingApprovalMiddleware
{
    private readonly RequestDelegate _next;

    public PendingApprovalMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, SignInManager<AppUser> signInManager)
    {
        if (context.User.Identity!.IsAuthenticated)
        {
            var user = await signInManager.UserManager.GetUserAsync(context.User);

            if (user != null && user.ActivationUser == ActivationEnum.Pending)
            {
                await signInManager.SignOutAsync();
                context.Response.Redirect("/index?message=approval_pending");
                return;
            }
        }

        await _next(context);
    }

}
