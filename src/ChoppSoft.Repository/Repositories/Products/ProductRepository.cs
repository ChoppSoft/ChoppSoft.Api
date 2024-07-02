using ChoppSoft.Domain.Interfaces.Products;
using ChoppSoft.Domain.Models.Products;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
