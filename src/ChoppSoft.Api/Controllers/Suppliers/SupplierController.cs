using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Suppliers.Services;
using ChoppSoft.Domain.Models.Suppliers.Services.Dtos;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Suppliers
{
    public class SupplierController : ControllerSoftBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(IMapper mapper,
                                  ISupplierService supplierService) : base(mapper)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            var response = await _supplierService.GetAll(query);
            var pagination = await _supplierService.GetPagination(query.PageSize);

            return ReturnBase<ICollection<SupplierViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _supplierService.GetById(id);

            return ReturnBase<SupplierViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierDto dto)
        {
            var response = await _supplierService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SupplierDto dto)
        {
            var response = await _supplierService.Update(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id)
        {
            var response = await _supplierService.Active(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id)
        {
            var response = await _supplierService.Inactivate(id);

            return ReturnBase(response);
        }
    }
}
