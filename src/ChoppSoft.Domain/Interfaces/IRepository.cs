using ChoppSoft.Infra.Bases;
using System.Linq.Expressions;

namespace ChoppSoft.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);
        Task AddRange(ICollection<TEntity> entity);
        Task<TEntity> GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, params string[] includes);
        Task<ICollection<TEntity>> GetAll(int page, int pageSize, params string[] includes);
        Task<ICollection<TEntity>> GetWithPagination(Expression<Func<TEntity, bool>> predicate, int page = 1, int pageSize = 25, params string[] includes);
        Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> predicate);
        Task Update(TEntity entity);
        Task UpdateRange(ICollection<TEntity> entities);
        Task Delete(Guid id);
        Task DeleteRange(ICollection<Guid> ids);
        Task<int> TotalCount();
        Task<int> SaveChanges();
    }
}
