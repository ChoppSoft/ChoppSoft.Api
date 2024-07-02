using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ControllerSoftBase : ControllerBase
    {
        protected IActionResult ReturnBase(ServiceResult result, int totalCount, int totalPages)
        {
            return result.Success ? Ok(new { Result = result.Entity, totalCount, totalPages })
                                  : BadRequest(string.Join("</br>", result.Errors));
        }

        protected IActionResult ReturnBase(ServiceResult result, string message = "")
        {
            return result.Success ? Ok(new { Result = result.Entity, Message = message }) 
                                  : BadRequest(string.Join("</br>", result.Errors));
        }
    }
}
