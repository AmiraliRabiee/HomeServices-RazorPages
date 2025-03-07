using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Identity;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Entites.OutputResult;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        Task<IdentityResult> Login(string username, string password);
        Task<IdentityResult> Register(CreateUserDto model, CancellationToken cancellationToken);
        Task<IdentityResult> Logout();
        Task<Result> UpdateInformation(UserDto model, CancellationToken cancellationToken);
        Task<Result> RemoveUser(int id, CancellationToken cancellationToken);
        List<AppUser> GetAll();
        AppUser GetById(int id);
        UserDto GetDtoById(int id);
        Task<CustomerDto> GetCustomerById(int id, CancellationToken cancellationToken);
        Task<Result> UpdateCustomer(CustomerDto model, CancellationToken cancellationToken);
        Task<Result> UpdateCustomerInformation(UserDto model, CancellationToken cancellationToken);
        Task<Result> CustomerUplpadingImage(UpdateUser model, UserDto user, CancellationToken cancellationToken);
        Task<Result> Payment(AppUser user, int orderId, float price, CancellationToken cancellationToken);
        Task<Result> Receive(float price, CancellationToken cancellationToken);
    }
}
