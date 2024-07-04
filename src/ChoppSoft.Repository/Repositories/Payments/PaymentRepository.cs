using ChoppSoft.Domain.Interfaces.Payments;
using ChoppSoft.Domain.Models.Payments;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Payments
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
