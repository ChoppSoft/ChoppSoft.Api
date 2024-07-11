using AutoMapper;
using ChoppSoft.Domain.Models.Deliveries.Services;
using ChoppSoft.Domain.Models.Deliveries.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Deliveries
{
    public class DeliveryController : ControllerSoftBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IMapper mapper,
                                   IDeliveryService deliveryService) : base(mapper)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var response = await _deliveryService.GetAll(page, pageSize);
            var pagination = await _deliveryService.GetPagination(pageSize);

            return ReturnBase<ICollection<DeliveryViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _deliveryService.GetById(id);

            return ReturnBase<DeliveryViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeliveryDto dto)
        {
            var response = await _deliveryService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DeliveryDto dto)
        {
            var response = await _deliveryService.Update(id, dto);

            return ReturnBase(response);
        }
    }
}
