using ChoppSoft.Domain.Interfaces.Customers;
using ChoppSoft.Domain.Models.Customers;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
