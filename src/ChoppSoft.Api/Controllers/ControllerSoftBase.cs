using AutoMapper;
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
        private readonly IMapper _mapper;
        public ControllerSoftBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected IActionResult ReturnBase<TView>(ServiceResult result, int totalCount, int totalPages)
        {
            var response = _mapper.Map<TView>(result.Entity);

            return result.Success ? Ok(new { Result = response, totalCount, totalPages })
                                  : BadRequest(string.Join("</br>", result.Errors));
        }

        protected IActionResult ReturnBase<TView>(ServiceResult result, string message = "")
        {
            var response = _mapper.Map<TView>(result.Entity);

            return result.Success ? Ok(new { Result = response, Message = message }) 
                                  : BadRequest(string.Join("</br>", result.Errors));
        }

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
