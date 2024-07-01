using ChoppSoft.Domain.Interfaces.Addresses;
using ChoppSoft.Domain.Models.Addresses;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Addresses
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
