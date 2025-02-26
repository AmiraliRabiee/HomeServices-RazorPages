using App.Domain.Core.Contracts.Repository.User;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.User
{
    public class RoleRepository(AppDbContext _appDbContext, UserManager<AppUser> _userManager, RoleManager<IdentityRole<int>> _roleManager) : IRoleRepository
    {
        public async Task<Result> AssignRole(int userId, int roleId, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _appDbContext.Users
                    .FindAsync(userId);
                if (user == null) return new Result { IsSuccess = false, Message = "کاربر یافت نشد" };

                var role = await _roleManager.FindByIdAsync(roleId.ToString());
                if (role == null) return new Result { IsSuccess = false, Message = "نقش نامعتبر است" };

                await _userManager.AddToRoleAsync(user, role.Name);
                return new Result { IsSuccess = true, Message = "نقش اختصاص داده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }
    }

}
