using ChoppSoft.Domain.Models.Warehouses.Services.Dtos;
using ChoppSoft.Domain.Models.Warehouses.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ChoppSoft.Api.ViewModels;

namespace ChoppSoft.Api.Controllers.Warehouses
{
    public class WarehouseController : ControllerSoftBase
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IMapper mapper, 
                                   IWarehouseService warehouseService) : base(mapper)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var response = await _warehouseService.GetAll(page, pageSize);
            var pagination = await _warehouseService.GetPagination(pageSize);

            return ReturnBase<ICollection<WarehouseViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _warehouseService.GetById(id);

            return ReturnBase<WarehouseViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WarehouseDto dto)
        {
            var response = await _warehouseService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] WarehouseDto dto)
        {
            var response = await _warehouseService.Update(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id)
        {
            var response = await _warehouseService.Active(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id)
        {
            var response = await _warehouseService.Inactivate(id);

            return ReturnBase(response);
        }
    }
}
