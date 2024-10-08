﻿using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Customers.Services;
using ChoppSoft.Domain.Models.Customers.Services.Dtos;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Customers
{
    public class CustomerController : ControllerSoftBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(IMapper mapper, 
                                  ICustomerService customerService) : base(mapper)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            var response = await _customerService.GetAll(query);
            var pagination = await _customerService.GetPagination(query.PageSize);

            return ReturnBase<ICollection<CustomerViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _customerService.GetById(id);

            return ReturnBase<CustomerViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto dto)
        {
            var response = await _customerService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CustomerDto dto)
        {
            var response = await _customerService.Update(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id)
        {
            var response = await _customerService.Active(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id)
        {
            var response = await _customerService.Inactivate(id);

            return ReturnBase(response);
        }

        [HttpGet("/BirthdaysOfTheMonth")]
        public async Task<IActionResult> BirthdaysOfTheMonth()
        {
            var response = await _customerService.BirthdaysOfTheMonth();

            return ReturnBase(response);
        }
    }
}
