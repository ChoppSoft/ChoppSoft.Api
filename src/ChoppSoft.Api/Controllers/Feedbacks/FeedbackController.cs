using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Feedbacks.Services;
using ChoppSoft.Domain.Models.Feedbacks.Services.Dtos;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Feedbacks
{
    public class FeedbackController : ControllerSoftBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IMapper mapper, 
                                  IFeedbackService feedbackService) : base(mapper)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            var response = await _feedbackService.GetAll(query);
            var pagination = await _feedbackService.GetPagination(query.PageSize);

            return ReturnBase<ICollection<FeedbackViewModel>>(response, pagination.TotalCount, pagination.TotalPages);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _feedbackService.GetById(id);

            return ReturnBase<FeedbackViewModel>(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FeedbackDto dto)
        {
            var response = await _feedbackService.Create(dto);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] FeedbackDto dto)
        {
            var response = await _feedbackService.Update(id, dto);

            return ReturnBase(response);
        }
    }
}
