using ChoppSoft.Domain.Models.Orders.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Orders.Services
{
    public interface IOrderService : IDisposable
    {
        Task<ServiceResult> Create(OrderDto dto);
        Task<ServiceResult> GetAll(QueryParams query);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> ChangeCustomer(Guid id, OrderCustomerDto dto);
        Task<ServiceResult> ChangeDeliveryDate(Guid id, OrderDeliveryDateDto dto);
        Task<ServiceResult> AddItems(Guid id, ICollection<OrderItemDto> dtos);
        Task<ServiceResult> RemoveItems(Guid id, ICollection<OrderItemIdDto> dtos);
        Task<(bool isValid, ICollection<string> errorMsgs)> ProcessValidation(Order order);
        Task<ServiceResult> Confirm(Guid id);
        Task<ServiceResult> UndoConfirmation(Guid id);
        Task<ServiceResult> Cancel(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
