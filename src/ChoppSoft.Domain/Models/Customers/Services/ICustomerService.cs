using ChoppSoft.Domain.Models.Customers.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Customers.Services
{
    public interface ICustomerService : IDisposable
    {
        Task<ServiceResult> Create(CustomerDto customer);
        Task<ServiceResult> Update(Guid id, CustomerDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
