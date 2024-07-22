﻿using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Payments.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Payments
{
    public class PaymentController : ControllerSoftBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(IMapper mapper, 
                                 PaymentService paymentService) : base(mapper)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var response = await _paymentService.GetAll(page, pageSize);
            var pagination = await _paymentService.GetPagination(pageSize);

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