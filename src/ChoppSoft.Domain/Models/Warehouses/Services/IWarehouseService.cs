using ChoppSoft.Domain.Models.Warehouses.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Warehouses.Services
{
    public interface IWarehouseService : IDisposable
    {
        Task<ServiceResult> Create(WarehouseDto product);
        Task<ServiceResult> Update(Guid id, WarehouseDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
