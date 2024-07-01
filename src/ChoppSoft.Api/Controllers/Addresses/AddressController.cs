using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Addresses
{
    public class AddressController : ControllerSoftBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 25)
        {
            return Ok();
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(/*[FromBody] ClientDto dto*/)
        {
            return Ok();
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id/*, [FromBody] ClientDto dto*/)
        {
            return Ok();
        }

        [HttpPut("{id:Guid}/Active")]
        public async Task<IActionResult> Active([FromRoute] Guid id/*, [FromBody] ClientDto dto*/)
        {
            return Ok();
        }

        [HttpPut("{id:Guid}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id/*, [FromBody] ClientDto dto*/)
        {
            return Ok();
        }
    }
}
