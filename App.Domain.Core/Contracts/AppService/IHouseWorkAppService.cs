﻿using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.AppService
{
    public interface IHouseWorkAppService
    {
        Task<Result> AddServiceAsync(SummHouseWorkDto model, CancellationToken cancellationToken);
        Task<Result> DeLeteServiceAsync(int id, CancellationToken cancellationToken);
        Task<Result> UpdateServiceAsync(UpdateHouseWork model, CancellationToken cancellationToken);
        Task<Result> SoftDeleteServiceAsync(HouseWork model, CancellationToken cancellationToken);
        HouseWork GetByIdAsync(int id);
        Task<List<SummHouseWorkDto>> GetAllAsync(CancellationToken cancellationToken);
        UpdateHouseWork GetServiceDto(int id);
        Task<List<SummHouseWorkDto>> GetServicesById(int id, CancellationToken cancellationToken);
        List<SummHouseWorkDto> GetServices();
        Task<int> GetServiceCount(int categoryId);
        Task<List<SummHouseWorkDto>> GetServicesByChildId(int id, CancellationToken cancellationToken);
        Task<SummHouseWorkDto> GetServiceByChildId(int id, CancellationToken cancellationToken);
        Task<SummHouseWorkDto> GetHouseWorkDto(int id, CancellationToken cancellationToken);
        Task<SummHouseWorkDto> GetServiceById(int id, CancellationToken cancellationToken);

    }
}
