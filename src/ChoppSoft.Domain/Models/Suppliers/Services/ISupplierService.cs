using ChoppSoft.Domain.Models.Suppliers.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Suppliers.Services
{
    public interface ISupplierService : IDisposable
    {
        Task<ServiceResult> Create(SupplierDto dto);
        Task<ServiceResult> Update(Guid id, SupplierDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
