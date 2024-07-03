using ChoppSoft.Domain.Interfaces.Routes;
using ChoppSoft.Domain.Models.Routes;
using ChoppSoft.Repository.Context;

namespace ChoppSoft.Repository.Repositories.Routes
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
