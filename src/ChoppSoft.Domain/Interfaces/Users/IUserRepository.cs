using ChoppSoft.Domain.Models.Users;

namespace ChoppSoft.Domain.Interfaces.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(string email, string password);
        Task<User> Get(string email, bool? active = true);
    }
}
