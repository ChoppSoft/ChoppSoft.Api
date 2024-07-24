using ChoppSoft.Application.Applications.Orders.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Application.Applications.Orders
{
    public interface IOrderApplication
    {
        Task<ServiceResult> Process(Guid id, OrderProcessDto dto);
    }
}
