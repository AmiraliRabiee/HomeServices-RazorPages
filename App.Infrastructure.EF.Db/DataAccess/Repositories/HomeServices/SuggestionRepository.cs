using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Result;
using App.Infrastructure.DataBase.EFCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EFCore.DataAccess.Repositories.HomeServices
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
                newSuggestion.SuggestPrice = suggestion.SuggestPrice;
                newSuggestion.DeliverDate = suggestion.DeliverDate;
                newSuggestion.CityId = suggestion.CityId;
                newSuggestion.OrderId = suggestion.OrderId;
                newSuggestion.HouseWorkId = suggestion.HouseWorkId;

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
                current.SuggestPrice = suggestion.SuggestPrice;
                current.SuggestPrice = suggestion.SuggestPrice;

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
            .Include(s => s.HouseWork)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

            if (suggestion is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");
            return suggestion;
        }

        public async Task<List<SummSuggestionDto>> GetSuggestion()
        {
            var suggestions = await _appDbContext.Suggestions
                .Include(s => s.HouseWork)
            .Select(s => new SummSuggestionDto
            {
                Description = s.Description,
                SuggestPrice = s.SuggestPrice,
                DeliverDate = s.DeliverDate,
                HouseWork = s.HouseWork.Title,
                ExpertId = s.Expert.Id,
                City = s.City.Name,
            }).ToListAsync();

            if (suggestions is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return suggestions;
        }
        #endregion
    }
}
