﻿using ChoppSoft.Domain.Models.Resources.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Resources.Services
{
    public interface IResourceService : IDisposable
    {
        Task<ServiceResult> Create(ResourceDto dto);
        Task<ServiceResult> Update(Guid id, ResourceDto dto);
        Task<ServiceResult> GetAll(QueryParams query);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
