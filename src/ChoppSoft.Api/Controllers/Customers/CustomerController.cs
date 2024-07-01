using ChoppSoft.Domain.Models.Customers.Services;
using ChoppSoft.Domain.Models.Customers.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Customers
{
    public class CustomerController : ControllerSoftBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {

            //var records = await _personAplic.GetAll(page, pageSize);

            //return records.Success ? Ok(records) : BadRequest(records);
            return Ok();
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var record = await _personAplic.GetById(id);


            //return record.Success ? Ok(record) : NotFound();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto dto)
        {
            var response = await _customerService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id/*, [FromBody] ClientDto dto*/)
        {
            //var record = await _personAplic.Update(id, dto);

            //return record.Success ? Ok(record) : BadRequest(record);
            return Ok();
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id/*, [FromBody] ClientDto dto*/)
        {
            //var record = await _personAplic.Update(id, dto);

            //return record.Success ? Ok(record) : BadRequest(record);
            return Ok();
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id/*, [FromBody] ClientDto dto*/)
        {
            //var record = await _personAplic.Update(id, dto);

            //return record.Success ? Ok(record) : BadRequest(record);
            return Ok();
        }
    }
}
