using ChoppSoft.Domain.Models.Payments.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Payments.Services
{
    public interface IPaymentService
    {
        Task<ServiceResult> Create(PaymentDto dto);
        Task<ServiceResult> Cancel(Guid id);
        Task<ServiceResult> GetAll(QueryParams query);
        Task<ServiceResult> GetById(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
