using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Models.Orders;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
