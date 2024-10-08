﻿using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Domain.Models.Orders.Services.Dtos;
using ChoppSoft.Domain.Models.Orders.Services.Validators;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Orders.Services
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

        public async Task<ServiceResult> GetAll(QueryParams query)
        {
            var orders = await _orderRepository.GetAllWithFilters(query, "Customer");

            return ServiceResult.Successful(orders);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id, "Customer", "Items", "Items.Product");

            return ServiceResult.Successful(order);
        }

        public async Task<ServiceResult> Create(OrderDto dto)
        {
            var order = new Order(dto.customerid, dto.deliveryDate);

            var validationResult = new OrderCreateValidator().Validate(order);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

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

            var validationResult = new OrderChangeCustomerValidator().Validate(order);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());


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

            var validationResult = new OrderChangeDeliveryDateValidator().Validate(order);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

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
            var order = await _orderRepository.GetByIdAsync(id, "Items");

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            var validationResult = new OrderUpdateItemValidator().Validate(order);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

            var existingProductIds = order.Items.Select(i => i.ProductId).ToHashSet();

            var newItems = dtos
                .Where(p => !existingProductIds.Contains(p.productid))
                .Select(p => new OrderItem(id, p.productid, p.quantity, p.unitprice))
                .ToList();

            if (!newItems.Any())
                return ServiceResult.Failed("Todos os itens já estão presentes no pedido.");

            order.AddItems(newItems);

            order.Totalizing();

            await _orderItemRepository.AddRange(newItems);
            await _orderRepository.Update(order);

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Item(ns) inserido(s) com sucesso."
            });
        }

        public async Task<ServiceResult> RemoveItems(Guid id, ICollection<OrderItemIdDto> dtos)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            var validationResult = new OrderUpdateItemValidator().Validate(order);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

            var orderItemsId = dtos.Select(p => p.id).ToList();

            await _orderItemRepository.DeleteRange(orderItemsId);

            order = await _orderRepository.GetByIdAsync(id, "Items");
            order.Totalizing();

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

            var validationResult = new OrderConfirmValidator().Validate(order);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

            order.MakeAsConfirmed();

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Pedido confirmado com sucesso."
            });
        }

        public async Task<(bool isValid, ICollection<string> errorMsgs)> ProcessValidation(Order order)
        {
            var validationResult = await new OrderProcessValidator().ValidateAsync(order);

            return (validationResult.IsValid, validationResult.Errors?.Select(e => e.ErrorMessage).ToList());
        }

        public async Task<ServiceResult> UndoConfirmation(Guid id)
        {
            var order = await _orderRepository.GetById(id);

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            var validationResult = new OrderUndoConfirmValidator().Validate(order);

            if(!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

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

            var validationResult = new OrderCancelValidator().Validate(order);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

            order.MakeAsCanceled();

            return ServiceResult.Successful(new
            {
                OrderId = order.Id,
                Message = "Pedido cancelado com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _orderRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _orderRepository?.Dispose();
            _orderItemRepository?.Dispose();
        }
    }
}
