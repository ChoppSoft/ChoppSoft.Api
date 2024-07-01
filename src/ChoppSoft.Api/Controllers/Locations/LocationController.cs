using ChoppSoft.Api.Aplications.Locations.Views;
using ChoppSoft.Domain.Models.Locations;
using ChoppSoft.Infra.Bases;
using Microsoft.AspNetCore.Mvc;

namespace ChoppSoft.Api.Controllers.Locations
{
    public class LocationController : ControllerSoftBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("SearchByZipCode/{code}")]
        public async Task<IActionResult> SearchByZipCode([FromRoute] string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return BadRequest();

            try
            {
                var response = await _locationService.SearchByZipCode(code);
                return ReturnBase(ServiceResult.Successful(new LocationResultView(response)));
            }
            catch (Exception ex)
            {
                return ReturnBase(ServiceResult.Failed(ex.Message));
            }
        }
    }
}
