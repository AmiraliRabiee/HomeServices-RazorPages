using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.OutputResult;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;

namespace App.InfraAccess.EFCore.DataAccess.Repositories.HomeServices
{
    public class SuggestionRepository(AppDbContext _appDbContext) : ISuggestionRepository
    {
        #region SuggestionCrud
        public async Task<Result> CreateSuggestion(Suggestion suggestion, CancellationToken cancellationToken)
        {
            try
            {
                var newSuggestion = new Suggestion();

                newSuggestion.Description = suggestion.Description;
                newSuggestion.DeliverDate = suggestion.DeliverDate;
                newSuggestion.OrderId = suggestion.OrderId;

                await _appDbContext.Suggestions.AddAsync(newSuggestion, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت افزوده شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> DeleteSuggestion(Suggestion suggestion, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.Suggestions
                    .FirstOrDefaultAsync(s => s.Id == suggestion.Id, cancellationToken);

                if (result is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };


                _appDbContext.Suggestions.Remove(result);
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> SoftDeleteSuggestion(Suggestion suggestion, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appDbContext.Suggestions
                    .FirstOrDefaultAsync(s => s.Id == suggestion.Id, cancellationToken);

                if (result is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };

                result.IsDeleted = true;
                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new Result { IsSuccess = true, Message = "با موفقیت حذف شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Result> UpdateSuggestion(Suggestion suggestion, CancellationToken cancellationToken)
        {
            try
            {
                var current = await _appDbContext.Suggestions
                    .FirstOrDefaultAsync(s => s.Id == suggestion.Id, cancellationToken);

                if (current is null)
                    return new Result { IsSuccess = false, Message = ".سفارشی با این شناسه یافت نشد" };

                current.DeliverDate = suggestion.DeliverDate;
                current.Description = suggestion.Description;

                await _appDbContext.SaveChangesAsync(cancellationToken);
                return new Result { IsSuccess = true, Message = ".به روزرسانی انجام شد" };
            }
            catch (Exception ex)
            {
                return new Result { IsSuccess = false, Message = $"{ex.Message}" };
            }
        }

        public async Task<Suggestion> GetSuggestionById(int id, CancellationToken cancellationToken)
        {
            var suggestion = await _appDbContext.Suggestions
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (suggestion is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");
            return suggestion;
        }

        public async Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken)
        {
            var suggestions = await _appDbContext.Suggestions
                .Where(s => s.OrderId == id)
            .Select(s => new SummSuggestionDto
            {
                ExpertId = s.Expert.Id,
                HouseWork = s.Order.HouseWork.Title,
                Description = s.Description,
                DeliverDate = s.DeliverDate.ToString("yyyy-MM-dd"),
                StausService = s.Order.StausService,
                City = s.Expert.City.Name,
                ExpertName = s.Expert.User.FirstName + s.Expert.User.LastName,
            }).ToListAsync();

            if (suggestions is null)
                throw new Exception(".پیشنهادی برای این سفارش ثبت نشده است");

            return suggestions;
        }

        public async Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken)
        {
            var suggestion = await _appDbContext.Suggestions
            .Select(s => new SummSuggestionDto
            {
                HouseWork = s.Order.HouseWork.Title,
                City = s.Order.Customer.City.Name,
                RunungTimeOrder = s.Order.RunningTime,
                DeliverDate = s.DeliverDate.ToString("yyyy-MM-dd"),
                Description = s.Description,
                StausService = s.Order.StausService,
            }).FirstOrDefaultAsync();
            if (suggestion is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");
            return suggestion;
        }

        public async Task<List<SummSuggestionDto>> GetAllDto(CancellationToken cancellationToken)
        {
            var suggestions = await _appDbContext.Suggestions
            .Select(s => new SummSuggestionDto
            {
                HouseWork = s.Order.HouseWork.Title,
                Description = s.Description,
                DeliverDate = s.DeliverDate.ToString("yyyy-MM-dd"),
                StausService = s.Order.StausService,
                City = s.Expert.City.Name,
            }).ToListAsync();

            if (suggestions is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return suggestions;
        }


        //int getcount
        //bool any true
        public int GetCount(int id)
        {
           var amount= _appDbContext.Suggestions
                .Where(o => o.OrderId == id)
                .Count();
            if (amount == 0)
                throw new Exception(".پیشنهادی ثبت نشده");
            return amount;
        }
        #endregion
    }
}
