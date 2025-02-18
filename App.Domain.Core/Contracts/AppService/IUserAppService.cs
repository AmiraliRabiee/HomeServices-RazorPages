using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Identity;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        Task<IdentityResult> Login(string username, string password);
        Task<IdentityResult> Register(CreateUserDto model,CancellationToken cancellationToken);
        Task<IdentityResult> Logout();
        Task<Result> UpdateInformation(AppUser model, CancellationToken cancellationToken);
        Task<Result> RemoveUser(AppUser model, CancellationToken cancellationToken);
    }
}
