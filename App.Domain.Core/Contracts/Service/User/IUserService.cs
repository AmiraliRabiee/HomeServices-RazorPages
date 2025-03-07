using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Core.Contracts.Service.User
{
    public interface IUserService
    {
        Task<Result> DeleteUser(int id, CancellationToken cancellationToken);
        Task<Result> SoftDeleteUser(AppUser user, CancellationToken cancellationToken);
        Task<Result> UpdateUser(UserDto user, CancellationToken cancellationToken);
        Task<Result> UpdateBalance(AppUser user, CancellationToken cancellationToken);
        Task<Result> ChangeStatus(AppUser user, CancellationToken cancellationToken);
        Task<UserDto> GetUserDetails(int id, CancellationToken cancellationToken);
        Task<List<Customer>> GetAllCustomers();
        Task<List<Expert>> GetAllExperts();
        List<AppUser> GetAll();
        AppUser GetById(int id);
        UserDto GetUserDto(int id);
        int GetCount();
        Task<Result> UpdateUserDto(int id, CancellationToken cancellationToken);
        Task<Result> UpdateCustomer(UserDto model, CancellationToken cancellationToken);
        Task<float> GetCustomerBalance(int id, CancellationToken cancellationToken);
        Task<float> GetBalance(AppUser user, CancellationToken cancellationToken);
        Task<Result> UpdateCustomer2(UserDto model, CancellationToken cancellationToken);
    }
}
