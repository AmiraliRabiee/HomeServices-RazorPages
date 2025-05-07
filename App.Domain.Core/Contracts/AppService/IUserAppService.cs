using App.Domain.Core.Dto.User;
using Microsoft.AspNetCore.Identity;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Dto.HomeService;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        Task<IdentityResult> Login(string username, string password);
        Task<IdentityResult> Register(CreateUserDto model, CancellationToken cancellationToken);
        Task<IdentityResult> Logout();
        Task<Result> UpdateInformation(UserDto model, CancellationToken cancellationToken);
        Task<Result> RemoveUser(int id, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAll(CancellationToken cancellationToken);
        AppUser GetById(int id);
        UserDto GetDtoById(int id);
        Task<CustomerDto?> GetCustomerById(int id, CancellationToken cancellationToken);
        Task<Result> UpdateCustomer(CustomerDto model, CancellationToken cancellationToken);
        Task<Result> UpdateCustomerInformation(UserDto model, CancellationToken cancellationToken);
        Task<Result> UplpadingImage(UpdateUser model, AppUser user, CancellationToken cancellationToken);
        Task<Result> Payment(AppUser user, int orderId, int expertId, float price, CancellationToken cancellationToken);
        Task<Result> UpdateExpert(ExpertDto model, CancellationToken cancellationToken);
        Task<ExpertDto?> GetExpertDto(int id, CancellationToken cancellationToken);
        Task UpdateExpertSkills(int expertId, List<int> houseWorkIds, CancellationToken cancellationToken);
        Task<List<int>> GetExpertSkills(int expertId, CancellationToken cancellationToken);
        Task<List<ExpertWorkDto>> GetExpertSkillsNameAsync(int expertId, CancellationToken cancellationToken);
        Task<int> GetSkillUpdateCount(int expertId, CancellationToken cancellationToken);
        Task IncrementSkillUpdateCount(int expertId, CancellationToken cancellationToken);
        Task<DateTime?> GetLastSkillUpdateDate(int expertId, CancellationToken cancellationToken);
        Task UpdateLastSkillUpdateDate(int expertId, DateTime updateDate, CancellationToken cancellationToken);
        Task ResetSkillUpdateCount(int expertId, CancellationToken cancellationToken);
        Task AcceptUserAsync(int id);
        Task RejectUserAsync(int id);

    }
}
