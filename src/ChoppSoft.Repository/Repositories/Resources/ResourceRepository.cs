using ChoppSoft.Domain.Interfaces.Resources;
using ChoppSoft.Domain.Models.Resources;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Resources
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        public ResourceRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
