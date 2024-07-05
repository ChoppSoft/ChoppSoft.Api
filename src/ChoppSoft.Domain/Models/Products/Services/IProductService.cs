using ChoppSoft.Domain.Models.Products.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Products.Services
{
    public interface IProductService : IDisposable
    {
        Task<ServiceResult> Create(ProductDto product);
        Task<ServiceResult> Update(Guid id, ProductDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
