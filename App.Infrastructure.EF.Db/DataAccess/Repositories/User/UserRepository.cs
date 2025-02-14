using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.Result;
using App.Domain.Core.Entites.User;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories
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
                user.Password = model.Password;
                user.RePassword = model.RePassword;
                user.Balance = model.Balance;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.RegisterAt = DateTime.Now;

                await _appDbContext.Users.AddAsync(user, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "کاربر ایجاد شد"};
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        
        }


        public async Task<Result> DeleteUser(AppUser user, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);

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

        public async Task<Result> UpdateUser(AppUser user, CancellationToken cancellationToken)
        {
            try
            {
                var currentUser = await _appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Id == user.Id ,cancellationToken);

                if (currentUser is null)
                    return new Result { IsSuccess = false, Message = ".کاربری با این شناسه یافت نشد" };

                var newUser = new UserDto();

                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Email = user.Email;
                currentUser.Password = user.Password;

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

        public async Task<UserDto> GetUserDetails(int id , CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

            if (result is not null)
            {
                return new UserDto
                {
                    FullName = $" {result.FirstName} {result.LastName}",
                    UserName = $"{result.UserName}",
                    Balance = result.Balance,
                    RoleId = result.RoleId,
                    ImagePath = result.ImagePath
                };
            }
            else
            {
                throw new Exception("کاربر پیدا نشد");
            }
        }
    }
}
