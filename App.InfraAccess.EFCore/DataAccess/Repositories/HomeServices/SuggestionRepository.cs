using App.Domain.Core.Contracts.Repository.HomeServices;
using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Dto.User;
using App.Domain.Core.Entites;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.User;
using App.Domain.Core.Enum;
using App.Infrastructure.EFCore.DataBase.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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
                newSuggestion.Id = suggestion.Id;
                newSuggestion.Description = suggestion.Description;
                newSuggestion.SuggestPrice = suggestion.SuggestPrice;
                newSuggestion.OrderId = suggestion.OrderId;
                newSuggestion.ExpertId = suggestion.ExpertId;
                newSuggestion.CreatedAt = DateTime.Now;
                newSuggestion.IsPresented = true;


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

                current.SuggestPrice = suggestion.SuggestPrice;
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

        public async Task<List<SummSuggestionDto>> GetSuggestionSkills(CustomerDto customer, CancellationToken cancellationToken)
        {
            var suggestions = await _appDbContext.Suggestions
        .Select(s => new
        {
            Suggestion = s,
            ExpertHouseWorks = s.Expert.ExpertWorksSkills
         .FirstOrDefault(eh => eh.HouseWorkId == s.Order.HouseWorkId),
            Order = s.Order,
            Expert = s.Expert,
        })
        .Where(s => s.Order.Customer.CityId == s.Suggestion.Expert.CityId)
        .Select(s => new SummSuggestionDto
        {
            CategoryName = s.Order.HouseWork.Category.Title,
            ParentCategoryName = s.Order.HouseWork.Category.ParentCategory.Title,
            HouseWork = s.Order.HouseWork.Title,
            Description = s.Suggestion.Description,
            SuggestPrice = s.Suggestion.SuggestPrice,
            RunungTimeOrder = s.Order.RunningTime,
            ExpertId = s.Expert.Id,
            StausService = s.Order.StausService,
            City = s.Expert.City.Name,
            ExpertName = s.Expert.User.FirstName + s.Expert.User.LastName,
        }).ToListAsync(cancellationToken);
            return suggestions;
        }

        public async Task<ExpertDto> GetExpertDto(int id, CancellationToken cancellationToken)
        {
            var experts = await _appDbContext.Suggestions
                .Where(s => s.ExpertId == id)
                .Select(s => new ExpertDto
                {
                    Id = s.Id,
                    PhoneNumber = s.Expert.User.PhoneNumber,
                    FullName = s.Expert.User.FirstName + " " + s.Expert.User.LastName,
                    Biographi = s.Expert.Biographi,
                    CityName = s.Expert.City.Name,
                    Skills = s.Expert.ExpertWorksSkills,
                    ImagePath = s.Expert.User.ImagePath
                }).FirstOrDefaultAsync(cancellationToken);
            if (experts is null)
                throw new Exception("با خظا مواجه شد");
            return experts;
        }

        public async Task<List<SummSuggestionDto>> GetSuggestionDetails(int id, CancellationToken cancellationToken)
        {
            var suggestions = await _appDbContext.Suggestions
                .Where(s => s.OrderId == id)
            .Select(s => new SummSuggestionDto
            {
                Id = s.Id,
                ExpertId = s.Expert.Id,
                HouseWork = s.Order.HouseWork.Title,
                Description = s.Description,
                SuggestPrice = s.SuggestPrice,
                StausService = s.Order.StausService,
                City = s.Expert.City.Name,
                OrderId = s.OrderId,
                ExpertName = s.Expert.User.FirstName + " " + s.Expert.User.LastName,
                IsAccepted = s.IsAccept,
                CompletionDate = s.Order.CompletionDate,
                RunungTimeOrder = s.Order.RunningTime,
            }).ToListAsync();

            if (suggestions is null)
                throw new Exception(".پیشنهادی برای این سفارش ثبت نشده است");

            return suggestions;
        }


        public async Task<SummSuggestionDto> GetSuggestionAccepted(int id, CancellationToken cancellationToken)
        {
            var suggestion = await _appDbContext.Suggestions
                .Where(s => s.OrderId == id && s.Order.IsConfrim == true)
                .Select(s => new SummSuggestionDto
                {
                    Id = s.Id,
                    ExpertId = s.Expert.Id,
                    HouseWork = s.Order.HouseWork.Title,
                    Description = s.Description,
                    SuggestPrice = s.SuggestPrice,
                    StausService = s.Order.StausService,
                    City = s.Expert.City.Name,
                    OrderId = s.OrderId,
                    ExpertName = s.Expert.User.FirstName + " " + s.Expert.User.LastName,
                }).FirstOrDefaultAsync(cancellationToken);
            return suggestion;
        }

        public async Task<SummSuggestionDto> GetSuggestionDto(int id, CancellationToken cancellationToken)
        {
            var suggestion = await _appDbContext.Suggestions
                .Where(s => s.OrderId == id)
                .Where(s => s.IsAccept == true)
            .Select(s => new SummSuggestionDto
            {
                Id = s.Id,
                HouseWork = s.Order.HouseWork.Title,
                City = s.Order.Customer.City.Name,
                RunungTimeOrder = s.Order.RunningTime,
                SuggestPrice = s.SuggestPrice,
                Description = s.Description,
                StausService = s.Order.StausService,
                ExpertId = s.ExpertId,
                CompletionDate = s.Order.CompletionDate,
            }).FirstOrDefaultAsync();
            if (suggestion is null)
                throw new Exception(".سفارشی با این شناسه یافت نشد");
            return suggestion;
        }

        public async Task<Result> AcceptSuggestion(int id, CancellationToken cancellationToken)
        {
            var suggestion = await _appDbContext.Suggestions
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (suggestion is null)
                return new Result { IsSuccess = false, Message = "تایید پیشنهاد با خطا مواجه شد" };
            suggestion.IsAccept = true;

            var save = await _appDbContext.SaveChangesAsync(cancellationToken);
            return new Result { IsSuccess = true, Message = "تایید پیشنهاد با موفقیت انجام شد" };
        }


        public async Task<List<SummSuggestionDto>> GetAllDto(CancellationToken cancellationToken)
        {
            var suggestions = await _appDbContext.Suggestions
            .Select(s => new SummSuggestionDto
            {
                HouseWork = s.Order.HouseWork.Title,
                Description = s.Description,
                SuggestPrice = s.SuggestPrice,
                StausService = s.Order.StausService,
                City = s.Expert.City.Name,
            }).ToListAsync();

            if (suggestions is null)
                throw new Exception(".لیست سفارش ها خالی میباشد");

            return suggestions;
        }
        public int GetCount(int id)
        {
            var amount = _appDbContext.Suggestions
                 .Where(o => o.OrderId == id)
                 .Count();
            if (amount == 0)
                throw new Exception(".پیشنهادی ثبت نشده");
            return amount;
        }

        public async Task<float> GetSuggestPrice(int id, CancellationToken cancellationToken)
        {
            var price = await _appDbContext.Suggestions
                .Where(s => s.Id == id)
                .Select(s => s.SuggestPrice)
                .FirstOrDefaultAsync(cancellationToken);
            if (price == 0)
                throw new Exception("مبلغی وجود ندارد");
            return price;
        }

        public async Task<SummSuggestionDto> GetExpertBySuggestion(int id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Suggestions
                .Where(s => s.Id == id)
                .Select(s => new SummSuggestionDto
                {
                    Id = s.Id,
                    ExpertName = s.Expert.User.FirstName + s.Expert.User.LastName,
                    ExpertId = s.ExpertId,
                }).FirstOrDefaultAsync(cancellationToken);
            if (result is null)
                throw new Exception("موردی موجود نمیباشد");
            return result;
        }

        public async Task<int> ActiveSuggestionsCount(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var suggestionsCount = await _appDbContext.Suggestions
                    .Where(s => s.Order.IsPayment == false && s.IsAccept == true && s.ExpertId == expertId)
                    .CountAsync(cancellationToken);
                return suggestionsCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DoneSuggestionsCount(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var suggestionsCount = await _appDbContext.Suggestions
                    .Where(s => s.Order.IsPayment == true && s.ExpertId == expertId)
                    .CountAsync(cancellationToken);
                return suggestionsCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SummSuggestionDto>> DoneSuggestions(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var suggestionsCount = await _appDbContext.Suggestions
                    .Where(s => s.Order.IsPayment == true && s.ExpertId == expertId)
                    .Select(s => new SummSuggestionDto
                    {
                        Id = s.Id,
                        ExpertName = s.Expert.User.FirstName + " " + s.Expert.User.LastName,
                        SuggestPrice = s.SuggestPrice,
                        CompletionDate = s.Order.CompletionDate,
                        //RunungTimeOrder = s.Order.RunningTime,
                        Description = s.Description,
                        HouseWork = s.Order.HouseWork.Title,
                        //CustomerAddress = s.Order.Customer.Address,
                        CategoryName = s.Order.HouseWork.Category.Title,
                        CityName = s.Expert.City.Name,
                        CustomerName = s.Order.Customer.User.FirstName + " " + s.Order.Customer.User,
                        StausService = s.Order.StausService,
                        CusomerId = s.Order.CustomerId,
                        CustomerImagePath = s.Order.Customer.User.ImagePath,
                        ImagePath = s.Order.Customer.User.ImagePath,
                    })
                    .ToListAsync(cancellationToken);
                return suggestionsCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SummSuggestionDto>> ActiveSuggestions(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                var suggestionsCount = await _appDbContext.Suggestions
                    .Where(s => s.Order.IsPayment == false && s.ExpertId == expertId && s.IsPresented == true)
                    .Select(s => new SummSuggestionDto
                    {
                        Id = s.Id,
                        StausService = s.Order.StausService,
                        ExpertName = s.Expert.User.FirstName + " " + s.Expert.User.LastName,
                        SuggestPrice = s.SuggestPrice,
                        CompletionDate = s.Order.CompletionDate,
                        Description = s.Description,
                        HouseWork = s.Order.HouseWork.Title,
                        CategoryName = s.Order.HouseWork.Category.Title,
                        CityName = s.Expert.City.Name,
                        CustomerName = s.Order.Customer.User.FirstName + " " + s.Order.Customer.User,
                        CusomerId = s.Order.CustomerId
                    })
                    .ToListAsync(cancellationToken);
                return suggestionsCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Suggestion?> GetLastSuggestion(int expertId,int orderId, CancellationToken cancellationToken)
        {
            return await _appDbContext.Suggestions
                .Where(s => s.ExpertId == expertId && s.OrderId == orderId)
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);
        }
        #endregion
    }
}
