using ChoppSoft.Domain.Interfaces.Feedbacks;
using ChoppSoft.Domain.Models.Feedbacks;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Feedbacks
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
