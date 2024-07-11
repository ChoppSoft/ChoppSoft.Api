using ChoppSoft.Domain.Models.Deliveries.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Deliveries.Services
{
    public interface IDeliveryService
    {
        Task<ServiceResult> Create(DeliveryDto dto);
        Task<ServiceResult> Update(Guid id, DeliveryDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
