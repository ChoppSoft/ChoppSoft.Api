using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Payments.Services;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Payments
{
    public class PaymentController : ControllerSoftBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IMapper mapper, 
                                 IPaymentService paymentService) : base(mapper)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            var response = await _paymentService.GetAll(query);
            var pagination = await _paymentService.GetPagination(query.PageSize);

            return ReturnBase<ICollection<PaymentViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _paymentService.GetById(id);

            return ReturnBase<PaymentViewModel>(response);
        }

        [HttpPut("{id:Guid}/Cancel")]
        public async Task<IActionResult> Cancel([FromRoute] Guid id)
        {
            var response = await _paymentService.Cancel(id);

            return ReturnBase(response);
        }
    }
}
