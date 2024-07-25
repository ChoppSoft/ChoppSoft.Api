using ChoppSoft.Application.Applications.Orders.Dtos;
using ChoppSoft.Domain.Interfaces.Deliveries;
using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Interfaces.Payments;
using ChoppSoft.Domain.Models.Deliveries;
using ChoppSoft.Domain.Models.Orders.Services;
using ChoppSoft.Domain.Models.Payments;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Application.Applications.Orders
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IOrderService _orderService;

        public OrderApplication(IOrderRepository orderRepository,
                                IPaymentRepository paymentRepository,
                                IDeliveryRepository deliveryRepository,
                                IOrderService orderService)
        {
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _deliveryRepository = deliveryRepository;
            _orderService = orderService;
        }

        public async Task<ServiceResult> Process(Guid id, OrderProcessDto dto)
        {
            var order = await _orderRepository.GetByIdAsync(id, "Items");

            if (order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {id}");

            order.SetAddress(dto.AddressId);

            var validator = await _orderService.ProcessValidation(order);

            if (!validator.isValid)
                return ServiceResult.Failed("A validação falhou", validator.errorMsgs);

            var payment = new Payment(order.Id,
                                      dto.payment.method,
                                      dto.payment.typediscount,
                                      dto.payment.discount,
                                      dto.payment.expenses);

            payment.SetAmont(order.TotalAmount);

            await _paymentRepository.Add(payment);

            order.MakeAsPaid();

            await _deliveryRepository.Add(new Delivery(order.Id,
                                                       dto.delivery.resourceid,
                                                       dto.delivery.scheduleddate,
                                                       dto.delivery.deliverydate));

            order.MakeAsShipped();
            order.MakeAsProcessing();

            await _orderRepository.Update(order);

            return ServiceResult.Successful("Pedido processado com sucesso, quando as entregas forem finalizadas o pedido irá confirmar automaticamente.");
        }
    }
}
