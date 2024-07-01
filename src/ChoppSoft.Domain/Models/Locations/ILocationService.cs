using ChoppSoft.Domain.Models.Locations.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Locations
{
    public interface ILocationService
    {
        Task<ViaCepResultDto> SearchByZipCode(string code);
    }
}
