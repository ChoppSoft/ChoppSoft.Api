using ChoppSoft.Domain.Interfaces.Deliveries;
using ChoppSoft.Domain.Models.Deliveries;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Deliveries
{
    public class DeliveryRepository : Repository<Delivery>, IDeliveryRepository
    {
        public DeliveryRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
