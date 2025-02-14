using App.Domain.Core.Entites.Result;
using App.Domain.Core.Entites;
using App.Infrastructure.DataBase.EFCore;
using App.Domain.Core.Contracts.Repository.User;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.User
{
    public class ExpertRepository(AppDbContext _appDbContext) : IExpertRepository
    {
        public async Task CreateExpert(int userId, string? biography, string? address ,CancellationToken cancellationToken)
        {
            var expert = new Expert { Id = userId, Biographi = biography, Points = 0 , Address = address};
            await _appDbContext.Experts.AddAsync(expert, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Result> UpdateExpert(Expert model, CancellationToken cancellationToken)
        {
            try
            {
                var expert = await _appDbContext.Experts
                    .FirstOrDefaultAsync(e => e.Id == model.Id, cancellationToken);
                if (expert is null)
                    return new Result { IsSuccess = false, Message = "کارشناس یافت نشد" };

                expert.Biographi = model.Biographi;
                expert.Points = model.Points;

                _appDbContext.Experts.Update(expert);
                await _appDbContext.SaveChangesAsync(cancellationToken);

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
    }
}
