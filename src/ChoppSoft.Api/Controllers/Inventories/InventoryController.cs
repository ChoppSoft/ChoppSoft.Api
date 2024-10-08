﻿using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Inventories.Services;
using ChoppSoft.Domain.Models.Inventories.Services.Dtos;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Inventories
{
    public class InventoryController : ControllerSoftBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IMapper mapper,
                                   IInventoryService inventoryService) : base(mapper)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            var response = await _inventoryService.GetAll(query);
            var pagination = await _inventoryService.GetPagination(query.PageSize);

            return ReturnBase<ICollection<InventoryViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _inventoryService.GetById(id);

            return ReturnBase<InventoryViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryDto dto)
        {
            var response = await _inventoryService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] InventoryDto dto)
        {
            var response = await _inventoryService.Update(id, dto);

            return ReturnBase(response);
        }

    }
}
