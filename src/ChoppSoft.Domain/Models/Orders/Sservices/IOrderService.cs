using ChoppSoft.Domain.Models.Orders.Sservices.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Orders.Sservices
{
    public interface IOrderService
    {
        Task<ServiceResult> Create(OrderDto dto);
        Task<ServiceResult> ChangeCustomer(Guid id, OrderCustomerDto dto);
        Task<ServiceResult> ChangeDeliveryDate(Guid id, OrderDeliveryDateDto dto);
    }
}
