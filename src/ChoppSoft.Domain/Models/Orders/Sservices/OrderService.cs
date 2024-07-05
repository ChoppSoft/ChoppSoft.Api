using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Interfaces.Products;
using ChoppSoft.Domain.Models.Orders.Sservices.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Orders.Sservices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ServiceResult> Create(OrderDto dto)
        {
            var order = new Order(dto.customerid, dto.deliveryDate);

            await _orderRepository.Add(order);

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Pedido cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> ChangeCustomer(Guid id, OrderCustomerDto dto)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            order.ChangeCustomer(dto.customerid);

            await _orderRepository.Update(order);

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Pedido atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> ChangeDeliveryDate(Guid id, OrderDeliveryDateDto dto)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            order.ChangeDeliveryDate(dto.deliveryDate);

            await _orderRepository.Update(order);

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Pedido atualizado com sucesso."
            });
        }
    }
}
