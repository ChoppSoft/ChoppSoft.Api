using ChoppSoft.Domain.Interfaces.Inventories;
using ChoppSoft.Domain.Models.Inventories;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Inventories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
