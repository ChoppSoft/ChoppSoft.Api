using ChoppSoft.Domain.Interfaces.Orders;
using ChoppSoft.Domain.Models.Orders.Items;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Orders
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
