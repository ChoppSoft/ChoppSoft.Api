using ChoppSoft.Domain.Models.Locations.Dtos;

namespace ChoppSoft.Api.ViewModels
{
    public class LocationViewModel
    {
        public LocationViewModel(ViaCepResultDto dto)
        {
            ZipCode = dto.CEP;
            Street = dto.Logradouro;
            District = dto.Bairro;
            City = dto.Localidade;
            State = dto.UF;
        }

        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country => "Brasil";
    }
}
