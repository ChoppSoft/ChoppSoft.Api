﻿using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Addresses.Services;
using ChoppSoft.Domain.Models.Addresses.Services.Dtos;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChoppSoft.Api.Controllers.Addresses
{
    public class AddressController : ControllerSoftBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IMapper mapper,
                                 IAddressService addressService) : base(mapper)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            var response = await _addressService.GetAll(query);
            var pagination = await _addressService.GetPagination(query.PageSize);

            return ReturnBase<ICollection<AddressViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _addressService.GetById(id);

            return ReturnBase<AddressViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddressDto dto)
        {
            var response = await _addressService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddressDto dto)
        {
            var response = await _addressService.Update(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/SetAsDefault")]
        public async Task<IActionResult> SetAsDefault([FromRoute] Guid id)
        {
            var response = await _addressService.SetAsDefault(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id)
        {
            var response = await _addressService.Active(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id)
        {
            var response = await _addressService.Inactivate(id);

            return ReturnBase(response);
        }
    }
}
