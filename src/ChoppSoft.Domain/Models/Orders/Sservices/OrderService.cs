using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Domain.Models.Orders.Sservices.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Orders.Sservices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderService(IOrderRepository orderRepository, 
                            IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
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

        public async Task<ServiceResult> AddItems(Guid id, ICollection<OrderItemDto> dtos)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            order.AddItems(dtos.Select(p => new OrderItem(id,
                                                          p.productid,
                                                          p.quantity,
                                                          p.unitprice)).ToList());

            await _orderRepository.Update(order);

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Item(ns) inserido(s) com sucesso."
            });
        }

        public async Task<ServiceResult> RemoveItems(Guid id, ICollection<OrderItemIdDto> dtos)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            var orderItemsId = dtos.Select(p => p.id).ToList();
            var orderItems = await _orderItemRepository.Get(p => orderItemsId.Contains(p.Id));

            order.RemoveItems(orderItems);

            await _orderRepository.Update(order);

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Item(ns) removidos(s) com sucesso."
            });
        }

        public async Task<ServiceResult> Confirm(Guid id)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            order.MakeAsConfirmed();

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Pedido confirmado com sucesso."
            });
        }

        public async Task<ServiceResult> UndoConfirmation(Guid id)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            order.UndoConfirme();

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Confirmação desfeita com sucesso."
            });
        }

        public async Task<ServiceResult> Cancel(Guid id)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            order.MakeAsCanceled();

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Pedido cancelado com sucesso."
            });
        }

        public void Dispose()
        {
            _orderRepository?.Dispose();
        }
    }
}
