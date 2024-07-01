using ChoppSoft.Domain.Models.Locations.Dtos;
using ChoppSoft.Infra.Helpers;

namespace ChoppSoft.Domain.Models.Locations
{
    public class LocationService : ILocationService
    {
        private const string URL = "https://viacep.com.br/ws/{0}/json";

        public async Task<ViaCepResultDto> SearchByZipCode(string code)
        {
            var url = string.Format(URL, code);

            var httpHelper = new HttpHelper(url);

            return await httpHelper.GetAsync<ViaCepResultDto>();
        }
    }
}
