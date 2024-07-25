using AutoMapper;
using ChoppSoft.Api.ViewModels;
using ChoppSoft.Domain.Models.Deliveries.Enums;
using ChoppSoft.Domain.Models.Deliveries.Services;
using ChoppSoft.Domain.Models.Deliveries.Services.Dtos;
using ChoppSoft.Infra.Bases;
using Humanizer;
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
        public async Task<IActionResult> GetAll([FromQuery] QueryParams query)
        {
            var response = await _deliveryService.GetAll(query);
            var pagination = await _deliveryService.GetPagination(query.PageSize);

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

        [HttpPut("{id:Guid}/MakeAsCollecting")]
        public async Task<IActionResult> MakeAsCollecting([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.Collecting);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/UndoCollecting")]
        public async Task<IActionResult> UndoCollecting([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.Scheduled);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/MakeAsCollectingFinished")]
        public async Task<IActionResult> MakeAsCollectingFinished([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.CollectFinished);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/UndoCollectingFinished")]
        public async Task<IActionResult> UndoCollectingFinished([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.Collecting);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/MakeAsInProgess")]
        public async Task<IActionResult> MakeAsInProgess([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.InProgress);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/UndoInProgess")]
        public async Task<IActionResult> UndoInProgess([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.CollectFinished);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/MakeAsInConference")]
        public async Task<IActionResult> MakeAsInConference([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.Conference);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/UndoInConference")]
        public async Task<IActionResult> UndoInConference([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.InProgress);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/MakeAsComplete")]
        public async Task<IActionResult> MakeAsComplete([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.Completed);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/UndoComplete")]
        public async Task<IActionResult> UndoComplete([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.Conference);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/MakeAsFail")]
        public async Task<IActionResult> MakeAsFail([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.Failed);

            return ReturnBase(response);
        }

        [HttpPut("{id:Guid}/UndoFail")]
        public async Task<IActionResult> UndoFail([FromRoute] Guid id)
        {
            var response = await _deliveryService.SetStatus(id, EnumDeliveryStatus.InProgress);

            return ReturnBase(response);
        }
    }
}
