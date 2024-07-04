using ChoppSoft.Domain.Interfaces.Warehouses;
using ChoppSoft.Domain.Models.Warehouses;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Warehouses
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
