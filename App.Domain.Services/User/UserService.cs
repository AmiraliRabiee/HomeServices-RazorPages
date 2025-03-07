using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services.User
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {
        public Task<Result> ChangeStatus(AppUser user, CancellationToken cancellationToken)
            => _userRepository.ChangeStatus(user, cancellationToken);

        public Task<Result> DeleteUser(int id, CancellationToken cancellationToken)
            => _userRepository.DeleteUser(id, cancellationToken);

        public List<AppUser> GetAll()
            => _userRepository.GetAll();

        public Task<List<Customer>> GetAllCustomers()
            => _userRepository.GetAllCustomers();

        public Task<List<Expert>> GetAllExperts()
            => _userRepository.GetAllExperts();

        public async Task<float> GetBalance(AppUser user, CancellationToken cancellationToken)
            => await _userRepository.GetBalance(user,cancellationToken);

        public AppUser GetById(int id)
            => _userRepository.GetById(id);

        public int GetCount()
            => _userRepository.GetCount();

        public async Task<float> GetCustomerBalance(int id, CancellationToken cancellationToken)
            => await _userRepository.GetCustomerBalance(id, cancellationToken);

        public Task<UserDto> GetUserDetails(int id, CancellationToken cancellationToken)
            => _userRepository.GetUserDetails(id, cancellationToken);

        public UserDto GetUserDto(int id)
            => _userRepository.GetDtoById(id); 

        public Task<Result> SoftDeleteUser(AppUser user, CancellationToken cancellationToken)
            => _userRepository.SoftDeleteUser(user, cancellationToken);

        public Task<Result> UpdateBalance(AppUser user, CancellationToken cancellationToken)
            => _userRepository.UpdateBalance(user, cancellationToken);

        public Task<Result> UpdateCustomer(UserDto model, CancellationToken cancellationToken)
            => _userRepository.UpdateCustomer(model, cancellationToken);

        public async Task<Result> UpdateCustomer2(UserDto model, CancellationToken cancellationToken)
            => await _userRepository.UpdateCustomer2(model, cancellationToken);

        public Task<Result> UpdateUser(UserDto user, CancellationToken cancellationToken)
            => _userRepository.UpdateUser(user, cancellationToken);

        public Task<Result> UpdateUserDto(int id, CancellationToken cancellationToken)
            => _userRepository.UpdateUserDto(id, cancellationToken);
    }
}
