using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Contracts.Service.User;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;

namespace App.Domain.Services.User
{
    public class UserService(IUserRepository _userRepository,
        IAdminRepository _adminRepository,
        IOrderRepository _orderRepository,
        IExpertRepository _expertRepository) : IUserService
    {
        public Task<Result> ChangeStatus(AppUser user, CancellationToken cancellationToken)
            => _userRepository.ChangeStatus(user, cancellationToken);

        public async Task<Result> DeleteUser(int id, CancellationToken cancellationToken)
            => await _userRepository.DeleteUser(id, cancellationToken);

        public async Task<List<UserDto>> GetAll(CancellationToken cancellationToken)
            =>await _userRepository.GetAll(cancellationToken);

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

        public async Task<float> GetBalance(int id, CancellationToken cancellationToken)
            => await _userRepository.GetBalance(id, cancellationToken);

        public Task<UserDto> GetUserDetails(int id, CancellationToken cancellationToken)
            => _userRepository.GetUserDetails(id, cancellationToken);


        public async Task<Result> Payment(AppUser user, int orderId, float price, CancellationToken cancellationToken)
        {
            var balance = await GetBalance(user, cancellationToken);

            if (balance == 0)
                return new Result { IsSuccess = false, Message = "موجودی حساب شما خالی میباشد" };
            if (balance < price)
                return new Result { IsSuccess = false, Message = "مبلغ سفارش بیشتر از مبلغ موجودی شما میباشد . لطفا افزایش موجودی انجام دهید" };
            if (balance >= price)
            {
                user.Balance = balance - price;
                var result = await UpdateBalance(user, cancellationToken);
                if (result.IsSuccess)
                {
                    await _orderRepository.ChangeToPayment(orderId, cancellationToken);
                    return new Result { IsSuccess = true, Message = "پرداخت با موفقیت انجام شد" };

                }
                return new Result { IsSuccess = false, Message = "در برداشت از حساب مشکلی پیش آمده است" };
            }
            return new Result { IsSuccess = false, Message = "با خطا مواجه شد" };
        }

        public async Task<Result> AdminReceive(float price, CancellationToken cancellationToken)
        {
            var adminBalance = await _adminRepository.GetAdminBalance(cancellationToken);
            var profit = await _adminRepository.GetProfit(cancellationToken);
            adminBalance += price * profit;
            var result = await _adminRepository.UpdateBalance(adminBalance, cancellationToken);
            if (result.IsSuccess)
                return new Result { IsSuccess = true, Message = result.Message };
            return new Result { IsSuccess = false, Message = result.Message };
        }


        public async Task<Result> ExpertReceive(AppUser user, float price, CancellationToken cancellationToken)
        {
            if (price <= 0)
            {
                return new Result { IsSuccess = false, Message = "Invalid price value." };
            }
            var expertBalance = await GetBalance(user, cancellationToken);
            var profitPercentage = await _adminRepository.GetProfit(cancellationToken);

            if (profitPercentage < 0 || profitPercentage >= 1)
            {
                return new Result { IsSuccess = false, Message = "Invalid profit percentage." };
            }

            var deductedAmount = price * profitPercentage;
            var amountToDeposit = price - deductedAmount;
            expertBalance += amountToDeposit;

            
            var result = await UpdateBalance(user,cancellationToken);
            if (result.IsSuccess)
                return new Result { IsSuccess = true, Message = result.Message };
            return new Result { IsSuccess = false, Message = result.Message };
        }

        public UserDto GetUserDto(int id)
            => _userRepository.GetDtoById(id); 

        public Task<Result> SoftDeleteUser(AppUser user, CancellationToken cancellationToken)
            => _userRepository.SoftDeleteUser(user, cancellationToken);

        public Task<Result> UpdateBalance(AppUser user, CancellationToken cancellationToken)
            => _userRepository.UpdateBalance(user, cancellationToken);

        public Task<Result> UpdateCustomer(UserDto model, CancellationToken cancellationToken)
            => _userRepository.UpdateCustomer(model, cancellationToken);

        public async Task<Result> UpdateImage(AppUser model, CancellationToken cancellationToken)
            => await _userRepository.UpdateImage(model, cancellationToken);

        public Task<Result> UpdateUser(UserDto user, CancellationToken cancellationToken)
            => _userRepository.UpdateUser(user, cancellationToken);

        public Task<Result> UpdateUserDto(int id, CancellationToken cancellationToken)
            => _userRepository.UpdateUserDto(id, cancellationToken);

        public async Task AcceptUser(int id)
            => await _userRepository.AcceptUser(id);

        public async Task RejectUser(int id)
            => await _userRepository.RejectUser(id);
    }
}
