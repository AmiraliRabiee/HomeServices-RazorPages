using App.Domain.Core.Contracts.Repository.User;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Entites.OutputResult;
using App.Infrastructure.EFCore.DataBase.Common;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites.Service;
using App.Domain.Core.Dto;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.User
{
    public class ExpertRepository(AppDbContext _appDbContext) : IExpertRepository
    {
        public async Task CreateExpert(int userId, string? biography, string? address, CancellationToken cancellationToken)
        {
            var expert = new Expert { Id = userId, Biographi = biography, Points = 0, Address = address };
            await _appDbContext.Experts.AddAsync(expert, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result> UpdateExpert(ExpertDto model, CancellationToken cancellationToken)
        {
            try
            {
                var expert = await _appDbContext.Experts
                    .FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken);
                if (expert is null)
                    return new Result { IsSuccess = false, Message = "کارشناس یافت نشد" };

                expert.Biographi = string.IsNullOrEmpty(model.Biographi) ? model.Biographi : model.Biographi;
                expert.CityId = model.CityId;
                expert.User.FirstName = model.FirstName;
                expert.User.LastName = model.LastName;
                expert.User.ImagePath = model.ImagePath;
                expert.User.Balance = model.Balance;

                _appDbContext.Experts.Update(expert);
                var update = await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "کارشناس به‌روزرسانی شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteExpert(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var expert = await _appDbContext.Experts
                    .FirstOrDefaultAsync(e => e.Id == expertId, cancellationToken);
                if (expert is null)
                    return new Result { IsSuccess = false, Message = "کارشناس یافت نشد" };

                _appDbContext.Experts.Remove(expert);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "کارشناس حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> SoftDeleteExpert(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var expert = await _appDbContext.Experts
                    .FirstOrDefaultAsync(e => e.Id == expertId, cancellationToken);
                if (expert is null)
                    return new Result { IsSuccess = false, Message = "کارشناس یافت نشد" };

                expert.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "کارشناس حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<ExpertDto?> GetExpertDto(int id , CancellationToken cancellationToken)
        {
            var expert = await _appDbContext.Experts
                .Select(e => new ExpertDto
                {
                    Id = e.Id,
                    FirstName = e.User.FirstName,
                    LastName = e.User.LastName,
                    CityId = e.CityId,
                    CityName = e.City.Name,
                    ImagePath = e.User.ImagePath,
                    Balance = e.User.Balance,
                    Biographi = e.Biographi,
                    PhoneNumber = e.User.PhoneNumber,
                    AppUser = e.User,
                    FullName = e.User.FirstName + " " + e.User.LastName,
                })
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            return expert;
        }

        public async Task<Result> UpdateBalance(int id , float balance, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
            user.Balance = balance;
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new Result { IsSuccess = true };
        }

        public async Task<List<SearchResultDto>> GetForSearch(string item)
        {
            var experts = await _appDbContext.Experts
                .Where(e => e.User.FirstName.Contains(item) || e.User.LastName.Contains(item))
                .Select(e => new SearchResultDto
                {
                    Id = e.Id,
                    FullName = e.User.FirstName + " " + e.User.LastName,
                    Type = "Expert"
                })
                .ToListAsync();

            return experts;
        }

        public async Task<int> GetSkillUpdateCount(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _appDbContext.Experts.FirstOrDefaultAsync(e => e.Id == expertId);
            return expert?.SkillUpdateCount ?? 0;
        }

        public async Task IncrementSkillUpdateCount(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _appDbContext.Experts.FindAsync(expertId);
            if (expert != null)
            {
                expert.SkillUpdateCount++;
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
        }


        public async Task<DateTime?> GetLastSkillUpdateDate(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _appDbContext.Experts.FindAsync(expertId);
            return expert?.LastSkillUpdateDate;
        }

        public async Task UpdateLastSkillUpdateDate(int expertId, DateTime updateDate, CancellationToken cancellationToken)
        {
            var expert = await _appDbContext.Experts.FindAsync(expertId);
            if (expert != null)
            {
                expert.LastSkillUpdateDate = updateDate;
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task ResetSkillUpdateCount(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _appDbContext.Experts.FindAsync(expertId);
            if (expert != null)
            {
                expert.SkillUpdateCount = 0;
                await _appDbContext.SaveChangesAsync(cancellationToken);
            }
        }

    }
}
