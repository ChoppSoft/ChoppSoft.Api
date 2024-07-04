using ChoppSoft.Domain.Models.Inventories.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Inventories.Services
{
    public interface IInventoryService
    {
        Task<ServiceResult> Create(InventoryDto dto);
        Task<ServiceResult> Update(Guid id, InventoryDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
