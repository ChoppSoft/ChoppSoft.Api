using ChoppSoft.Domain.Interfaces.Users;
using ChoppSoft.Domain.Models.Users;
using ChoppSoft.Infra.Extensions;
using ChoppSoft.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace ChoppSoft.Repository.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyDbContext dbcontext) : base(dbcontext)
        {
        }

        public async Task<User> Get(string email, string password)
        {
            var user = await _dbSetEntity.FirstOrDefaultAsync(user => user.Email == email && user.Active);

            return (user is not null && user.Password.VerifyPassword(password)) ? user : null;
        }

        public async Task<User> Get(string email, bool? active = true)
        {
            return await _dbSetEntity.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower() && user.Active);
        }
    }
}
