using ChoppSoft.Domain.Interfaces.Suppliers;
using ChoppSoft.Domain.Models.Suppliers;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Suppliers
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
