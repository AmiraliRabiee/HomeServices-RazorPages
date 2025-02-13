﻿using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.Result;

namespace App.Domain.Core.Contracts.Repository.HomeServices
{
    public interface ISuggestionRepository
    {
        Task<Result> CreateSuggestion(SummSuggestionDto suggestion, CancellationToken cancellationToken);
        Task<Result> DeleteSuggestion(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Result> UpdateSuggestion(Suggestion suggestion, CancellationToken cancellationToken);
        Task<Suggestion> GetSuggestionById(int id, CancellationToken cancellationToken);
        Task<List<SummSuggestionDto>> GetSuggestion();
    }
}
