﻿using ChoppSoft.Domain.Models.Routes.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Routes.Services
{
    public interface IRouteService
    {
        Task<ServiceResult> Create(RouteDto dto);
        Task<ServiceResult> GetAll(QueryParams query);
        Task<ServiceResult> GetById(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
