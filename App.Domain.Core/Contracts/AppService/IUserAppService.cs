using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        Task<IdentityResult> Login(string username, string password);
        Task<IdentityResult> Register(CreateUserDto model,CancellationToken cancellationToken);
        Task<IdentityResult> Logout();
    }
}
