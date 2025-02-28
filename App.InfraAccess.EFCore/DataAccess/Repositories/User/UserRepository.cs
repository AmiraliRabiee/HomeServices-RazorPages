using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.User
{
    public class UserRepository(AppDbContext _appDbContext) : IUserRepository
    {
        public async Task<Result> Create(AppUser model, CancellationToken cancellationToken)
        {
            try
            {
                var user = new AppUser();

                user.UserName = model.UserName;
                user.Email = model.Email;
                //user.Password = model.Password;
                //user.RePassword = model.RePassword;
                user.Balance = model.Balance;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.RegisterAt = DateTime.Now;

                await _appDbContext.Users.AddAsync(user, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "کاربر ایجاد شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }

        }


        public async Task<Result> DeleteUser(int id, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

                if (currentUser is null)
                    return new Result { IsSuccess = false, Message = ".کاربری با این شناسه یافت نشد" };

                _appDbContext.Users.Remove(currentUser);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> SoftDeleteUser(AppUser user, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

                if (currentUser is null)
                    return new Result { IsSuccess = false, Message = ".کاربری با این شناسه یافت نشد" };

                currentUser.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateUser(UserDto user, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

                if (currentUser is null)
                    return new Result { IsSuccess = false, Message = ".کاربری با این شناسه یافت نشد" };

                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = user.Email;
                currentUser.UserName = user.UserName;
                currentUser.RoleId = user.RoleId;
                currentUser.ImagePath = user.ImagePath;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }


        public async Task<Result> UpdateUserDto(int id, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

                if (currentUser is null)
                    return new Result { IsSuccess = false, Message = ".کاربری با این شناسه یافت نشد" };
                var newUser = new AppUser()
                {
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Email = currentUser.Email,
                    UserName = currentUser.UserName,
                    RoleId = currentUser.RoleId,
                    ImagePath = currentUser.ImagePath,
                };

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateBalance(AppUser user, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

                if (currentUser is null)
                    return new Result { IsSuccess = false, Message = ".کاربری با این شناسه یافت نشد" };

                currentUser.Balance = user.Balance;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> ChangeStatus(AppUser user, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

                if (currentUser is null)
                    return new Result { IsSuccess = false, Message = ".کاربری با این شناسه یافت نشد" };

                currentUser.ActivationUser = user.ActivationUser;
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<UserDto> GetUserDetails(int id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

            if (result is null)
                throw new Exception("کاربر پیدا نشد");

            if (result.RoleId == 2)
            {
                //customer
                return new UserDto
                {
                    FullName = $" {result.FirstName} {result.LastName}",
                    UserName = $"{result.UserName}",
                    Balance = result.Balance,
                    RoleId = result.RoleId,
                    ImagePath = result.ImagePath,
                    CityId = result.Customer.City.Id,
                    Address = result.Customer.Address,
                    Orders = result.Customer.Orders, //inline if
                };
            }
            if (result.RoleId == 3)
            {
                //expert
                return new UserDto
                {
                    FullName = $" {result.FirstName} {result.LastName}",
                    UserName = $"{result.UserName}",
                    Balance = result.Balance,
                    RoleId = result.RoleId,
                    ImagePath = result.ImagePath,
                    CityId = result.Expert.City.Id,
                    Suggestions = result.Expert.Suggestions, // inline if
                };
            }
            return null;
        }



        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _appDbContext.Customers.ToListAsync();
            if (customers is null)
                throw new Exception(".مشتری ای وجود ندارد");

            return customers;
        }

        public async Task<List<Expert>> GetAllExperts()
        {
            var experts = await _appDbContext.Experts.ToListAsync();
            if (experts is null)
                throw new Exception(".مشتری ای وجود ندارد");

            return experts;
        }

        public List<AppUser> GetAll()
        {
            var users = _appDbContext.Users.ToList();
            if (users is null)
                throw new Exception(".کاربری وجود ندارد");
            return users;
        }

        public AppUser GetById(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user is null)
                throw new Exception(".کاربری با این شناسه وجود ندارد");
            return user;
        }

        public UserDto GetDtoById(int id)
        {
            var res = _appDbContext.Users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                UserName = u.UserName,
                Address = u.Customer.Address,
                Balance = u.Balance,
            }).FirstOrDefault(u => u.Id == id);
            return res;
        }

        public int GetCount()
            => _appDbContext.Users.Count();
    }
}
