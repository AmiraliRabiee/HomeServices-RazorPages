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
        Task<List<UserDto>> GetAll(CancellationToken cancellationToken);
        AppUser GetById(int id);
        UserDto GetUserDto(int id);
        int GetCount();
        Task<Result> UpdateUserDto(int id, CancellationToken cancellationToken);
        Task<Result> UpdateCustomer(UserDto model, CancellationToken cancellationToken);
        Task<float> GetBalance(int id, CancellationToken cancellationToken);
        Task<float> GetBalance(AppUser user, CancellationToken cancellationToken);
        Task<Result> UpdateImage(AppUser model, CancellationToken cancellationToken);
        Task AcceptUser(int id);
        Task RejectUser(int id);
        Task<Result> ExpertReceive(AppUser user, float price, CancellationToken cancellationToken);
        Task<Result> AdminReceive(float price, CancellationToken cancellationToken);
        Task<Result> Payment(AppUser user, int orderId, float price, CancellationToken cancellationToken);
    }
}
