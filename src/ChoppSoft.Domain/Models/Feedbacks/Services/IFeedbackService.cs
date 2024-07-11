using ChoppSoft.Domain.Models.Feedbacks.Services.Dtos;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Feedbacks.Services
{
    public interface IFeedbackService
    {
        Task<ServiceResult> Create(FeedbackDto dto);
        Task<ServiceResult> Update(Guid id, FeedbackDto dto);
        Task<ServiceResult> GetAll(int page, int pageSize);
        Task<ServiceResult> GetById(Guid id);
        Task<ServiceResult> Active(Guid id);
        Task<ServiceResult> Inactivate(Guid id);
        Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize);
    }
}
