﻿using App.Domain.Core.Dto.HomeService;
using App.Domain.Core.Entites.OutputResult;
using App.Domain.Core.Entites.Service;

namespace App.Domain.Core.Contracts.Service.HomeServices
{
    public interface IHouseWorkService
    {
        Task<Result> CreateService(SummHouseWorkDto service, CancellationToken cancellationToken);
        Task<Result> DeleteHomeService(int id, CancellationToken cancellationToken);
        Task<Result> SoftDeleteHomeService(HouseWork service, CancellationToken cancellationToken);
        Task<Result> UpdateHomeService(UpdateHouseWork service, CancellationToken cancellationToken);
        HouseWork GetById(int id);
        Task<List<SummHouseWorkDto>> GetAll(CancellationToken cancellationToken);
        UpdateHouseWork GetServiceDto(int id);
        List<SummHouseWorkDto> GetServicesById(int id);
        List<SummHouseWorkDto> GetServicesById();

    }
}
