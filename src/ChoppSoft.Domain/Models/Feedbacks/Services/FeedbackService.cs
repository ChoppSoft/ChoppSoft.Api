using ChoppSoft.Domain.Interfaces.Feedbacks;
using ChoppSoft.Domain.Models.Feedbacks.Services.Dtos;
using ChoppSoft.Domain.Models.Feedbacks.Services.Validators;
using ChoppSoft.Infra.Bases;

namespace ChoppSoft.Domain.Models.Feedbacks.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<ServiceResult> Create(FeedbackDto dto)
        {
            var feedback = new Feedback(dto.customerid,
                                        dto.orderid,
            dto.comments,
                                        dto.rating);

            var validationResult = new FeedbackCreateValidator().Validate(feedback);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _feedbackRepository.Add(feedback);

            return ServiceResult.Successful(new
            {
                FeedbackId = feedback.Id,
                Message = "Feedback cadastrado com sucesso."
            });
        }

        public async Task<ServiceResult> Update(Guid id, FeedbackDto dto)
        {
            var feedback = await _feedbackRepository.GetById(id);

            if (feedback is null)
                return ServiceResult.Failed($"Não foi possível encontrar o feedback de código {id}");

            feedback.Update(dto);

            var validationResult = new FeedbackUpdateValidator().Validate(feedback);

            if (!validationResult.IsValid)
                return ServiceResult.Failed(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            await _feedbackRepository.Update(feedback);

            return ServiceResult.Successful(new
            {
                FeedbackId = feedback.Id,
                Message = "Feedback atualizado com sucesso."
            });
        }

        public async Task<ServiceResult> GetAll(int page, int pageSize)
        {
            var feedbacks = await _feedbackRepository.GetAll(page, pageSize, "Customer", "Order");

            return ServiceResult.Successful(feedbacks);
        }

        public async Task<ServiceResult> GetById(Guid id)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(id, "Customer", "Order");

            return ServiceResult.Successful(feedback);
        }

        public async Task<ServiceResult> Active(Guid id)
        {
            var feedback = await _feedbackRepository.GetById(id);

            if (feedback is null)
                return ServiceResult.Failed($"Não foi possível encontrar o feedback de código {id}");

            feedback.Activate();

            await _feedbackRepository.Update(feedback);

            return ServiceResult.Successful(new
            {
                FeedbackId = feedback.Id,
                Message = "Feedback ativado com sucesso."
            });
        }

        public async Task<ServiceResult> Inactivate(Guid id)
        {
            var feedback = await _feedbackRepository.GetById(id);

            if (feedback is null)
                return ServiceResult.Failed($"Não foi possível encontrar o feedback de código {id}");

            feedback.Disable();

            await _feedbackRepository.Update(feedback);

            return ServiceResult.Successful(new
            {
                FeedbackId = feedback.Id,
                Message = "Feedback desabilitado com sucesso."
            });
        }

        public async Task<(int TotalCount, int TotalPages)> GetPagination(int pageSize)
        {
            var totalCount = await _feedbackRepository.TotalCount();
            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            return (totalCount, totalPages);
        }

        public void Dispose()
        {
            _feedbackRepository?.Dispose();
        }
    }
}
