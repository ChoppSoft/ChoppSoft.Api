using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Routes.Services;
using ChoppSoft.Domain.Models.Routes.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Routes
{
    public class RouteController : ControllerSoftBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IMapper mapper, 
                               IRouteService routeService) : base(mapper)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var response = await _routeService.GetAll(page, pageSize);
            var pagination = await _routeService.GetPagination(pageSize);

            return ReturnBase<ICollection<RouteViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _routeService.GetById(id);

            return ReturnBase<RouteViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RouteDto dto)
        {
            var response = await _routeService.Create(dto);

            return ReturnBase(response);
        }
    }
}
