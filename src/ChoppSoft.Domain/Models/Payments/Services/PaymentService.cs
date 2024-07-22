using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Interfaces.Payments;
using ChoppSoft.Domain.Models.Payments.Services.Dtos;
using ChoppSoft.Domain.Models.Payments.Services.Validators;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Payments.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public PaymentService(IPaymentRepository paymentRepository, 
                              IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ServiceResult> Create(PaymentDto dto)
        {
            var payment = new Payment(dto.orderId, dto.method, dto.typediscount, dto.discount, dto.expenses);

            var order = await _orderRepository.GetById(dto.orderId);

            if(order is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pedido de código {dto.orderId}");

            payment.SetAmont(order.TotalAmount);

            var validationResult = new PaymentCreateValidator().Validate(payment);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

            await _paymentRepository.Add(payment);

            return ServiceResult.Successful(new
            {
                PaymentId = payment.Id,
                Message = "Pagamento cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Cancel(Guid id)
        {
            var payment = await _paymentRepository.GetById(id);

            if(payment is null)
                return ServiceResult.Failed($"Não foi possível encontrar o pagamento de código {id}");

            var validationResult = new PaymentCancelValidator().Validate(payment);

            if (!validationResult.IsValid)
                return ServiceResult.Failed("A validação falhou.", validationResult.Errors?.Select(e => e.ErrorMessage).ToList());

            payment.MakeAsCanceled();

            return ServiceResult.Successful(new
            {
                PaymentId = payment.Id,
                Message = "Pagamento cancelado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var payments = await _paymentRepository.GetAll(page, pageSize, "Order");

            return ServiceResult.Successful(payments);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id, "Order");

            return ServiceResult.Successful(payment);
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _paymentRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _paymentRepository?.Dispose();
            _orderRepository?.Dispose();
        }
    }
}
