﻿using ChoppSoft.Domain.Interfaces.Deliveries;
using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Models.Deliveries.Enums;
using ChoppSoft.Domain.Models.Deliveries.Services.Dtos;
using ChoppSoft.Domain.Models.Deliveries.Services.Validators;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Deliveries.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IOrderRepository _orderRepository;
        public DeliveryService(IDeliveryRepository deliveryRepository, IOrderRepository orderRepository)
        {
            _deliveryRepository = deliveryRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ServiceResult> Create(DeliveryDto dto)
        {
            var delivery = new Delivery(dto.orderid,
                                        dto.resourceid,
                                        dto.scheduleddate,
                                        dto.deliverydate);

            var validationResult = new DeliveryCreateValidator().Validate(delivery);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _deliveryRepository.Add(delivery);

            return ServiceResult.Successful(new
            {
                DeliveryId = delivery.Id,
                Message = "Entrega cadastrada com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, DeliveryDto dto)
        {
            var delivery = await _deliveryRepository.GetById(id);

            if (delivery is null)
                return ServiceResult.Failed($"Não foi possível encontrar a entrega de código {id}");

            delivery.Update(dto);

            var validationResult = new DeliveryUpdateValidator().Validate(delivery);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _deliveryRepository.Update(delivery);

            return ServiceResult.Successful(new
            {
                DeliveryId = delivery.Id,
                Message = "Entraga atualizada com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(QueryParams query)
        {
            var deliverys = await _deliveryRepository.GetAllWithFilters(query, "Order", "Resource");

            return ServiceResult.Successful(deliverys.OrderBy(x => x.DeliveryDate));
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var delivery = await _deliveryRepository.GetByIdAsync(id, "Order", "Resource");

            return ServiceResult.Successful(delivery);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var delivery = await _deliveryRepository.GetById(id);

            if (delivery is null)
                return ServiceResult.Failed($"Não foi possível encontrar a entrega de código {id}");

            delivery.Activate();

            await _deliveryRepository.Update(delivery);

            return ServiceResult.Successful(new
            {
                DeliveryId = delivery.Id,
                Message = "Entraga ativada com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var delivery = await _deliveryRepository.GetById(id);

            if (delivery is null)
                return ServiceResult.Failed($"Não foi possível encontrar a entrega de código {id}");

            delivery.Disable();

            await _deliveryRepository.Update(delivery);

            return ServiceResult.Successful(new
            {
                DeliveryId = delivery.Id,
                Message = "Entrega desabilitada com sucesso."
            });
        }

        public async Task<ServiceResult> SetStatus(Guid id, EnumDeliveryStatus status)
        {
            var delivery = await _deliveryRepository.GetById(id);

            if (delivery is null)
                return ServiceResult.Failed($"Não foi possível encontrar a entrega de código {id}");

            var order = await _orderRepository.GetById(delivery.OrderId);

            //validar etapa

            delivery.SetStatus(status);

            await _deliveryRepository.Update(delivery);

            order.MakeAsDelivered();
            order.MakeAsConfirmed();

            await _orderRepository.Update(order);

            return ServiceResult.Successful(new
            {
                DeliveryId = delivery.Id,
                Message = "Etapa alterada com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _deliveryRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _deliveryRepository?.Dispose();
        }
    }
}
