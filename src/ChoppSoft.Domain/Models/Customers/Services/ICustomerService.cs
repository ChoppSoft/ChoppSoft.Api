using ChoppSoft.Domain.Models.Customers.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Customers.Services
{
    public interface ICustomerService
    {
        Task<ServiceResult> Create(CustomerDto customer);
    }
}
