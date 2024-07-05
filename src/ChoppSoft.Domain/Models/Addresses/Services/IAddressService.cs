using ChoppSoft.Domain.Models.Addresses.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Addresses.Services
{
    public interface IAddressService : IDisposable
    {
        Task<ServiceResult> Create(AddressDto dto);
        Task<ServiceResult> Update(Guid id, AddressDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> SetAsDefault(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
