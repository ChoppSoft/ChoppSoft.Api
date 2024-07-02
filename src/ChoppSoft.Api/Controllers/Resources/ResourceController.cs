using ChoppSoft.Domain.Models.Resources.Services;
using ChoppSoft.Domain.Models.Resources.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Resources
{
    public class ResourceController : ControllerSoftBase
    {
        private readonly IResourceService _resourceService;
        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var response = await _resourceService.GetAll(page, pageSize);
            var pagination = await _resourceService.GetPagination(pageSize);

            return ReturnBase(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _resourceService.GetById(id);

            return ReturnBase(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResourceDto dto)
        {
            var response = await _resourceService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ResourceDto dto)
        {
            var response = await _resourceService.Update(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id)
        {
            var response = await _resourceService.Active(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id)
        {
            var response = await _resourceService.Inactivate(id);

            return ReturnBase(response);
        }
    }
}
