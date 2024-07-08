using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Orders.Services;
using ChoppSoft.Domain.Models.Orders.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Orders
{
    public class OrderController : ControllerSoftBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IMapper mapper,
                               IOrderService orderService) : base(mapper)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto dto)
        {
            var response = await _orderService.Create(dto);

            return ReturnBase(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            var response = await _orderService.GetAll(page, pageSize);
            var pagination = await _orderService.GetPagination(pageSize);

            return ReturnBase<ICollection<OrderViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _orderService.GetById(id);

            return ReturnBase<OrderWhitItemsViewModel>(response);
        }

        [HttpPut("{id:Guid}/ChangeCustomer")]
        public async Task<IActionResult> ChangeCustomer([FromRoute] Guid id, [FromBody] OrderCustomerDto dto)
        {
            var response = await _orderService.ChangeCustomer(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/ChangeDeliveryDate")]
        public async Task<IActionResult> ChangeDeliveryDate([FromRoute] Guid id, [FromBody] OrderDeliveryDateDto dto)
        {
            var response = await _orderService.ChangeDeliveryDate(id, dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/AddItem")]
        public async Task<IActionResult> AddItem([FromRoute] Guid id, [FromBody] OrderItemDto dto)
        {
            var response = await _orderService.AddItems(id, new List<OrderItemDto>() { dto });

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/AddItems")]
        public async Task<IActionResult> AddItems([FromRoute] Guid id, [FromBody] ICollection<OrderItemDto> dtos)
        {
            var response = await _orderService.AddItems(id, dtos);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/RemoveItem")]
        public async Task<IActionResult> RemoveItem([FromRoute] Guid id, [FromBody] OrderItemIdDto dto)
        {
            var response = await _orderService.RemoveItems(id, new List<OrderItemIdDto>() { dto });

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/RemoveItems")]
        public async Task<IActionResult> RemoveItems([FromRoute] Guid id, [FromBody] ICollection<OrderItemIdDto> dtos)
        {
            var response = await _orderService.RemoveItems(id, dtos);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Confirm")]
        public async Task<IActionResult> Confirm([FromRoute] Guid id)
        {
            var response = await _orderService.Confirm(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/UndoConfirmation")]
        public async Task<IActionResult> UndoConfirmation([FromRoute] Guid id)
        {
            var response = await _orderService.UndoConfirmation(id);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/Cancel")]
        public async Task<IActionResult> Cancel([FromRoute] Guid id)
        {
            var response = await _orderService.Cancel(id);

            return ReturnBase(response);
        }
    }
}
