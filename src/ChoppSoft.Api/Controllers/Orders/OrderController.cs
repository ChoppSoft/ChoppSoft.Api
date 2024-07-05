using AutoMapper;
using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Domain.Models.Orders.Sservices;
using ChoppSoft.Domain.Models.Orders.Sservices.Dtos;
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
            throw new NotImplementedException();
        }

        [HttpPut("{id:Guid}/AddItems")]
        public async Task<IActionResult> AddItems([FromRoute] Guid id, [FromBody] ICollection<OrderItemDto> dtos)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:Guid}/RemoveItem")]
        public async Task<IActionResult> RemoveItem([FromRoute] Guid id, [FromBody] OrderItemDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:Guid}/RemoveItems")]
        public async Task<IActionResult> RemoveItems([FromRoute] Guid id, [FromBody] ICollection<OrderItemDto> dtos)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:Guid}/Confirm")]
        public async Task<IActionResult> Confirm([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:Guid}/UndoConfirmation")]
        public async Task<IActionResult> UndoConfirmation([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:Guid}/Cancel")]
        public async Task<IActionResult> Cancel([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
