using ChoppSoft.Domain.Interfaces;
using ChoppSoft.Infra.Bases;
using ChoppSoft.Infra.Bases.Enums;
using ChoppSoft.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChoppSoft.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MyDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSetEntity;

        protected Repository(MyDbContext dbcontext)
        {
            _dbContext = dbcontext;
            _dbSetEntity = _dbContext.Set<TEntity>();
        }

        public virtual async Task<ICollection<TEntity>> GetAll(int page, int pageSize, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSetEntity;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> GetAllWithFilters(int page, int pageSize, ICollection<Filter> filters = null, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSetEntity;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (filters is not null && filters.Any())
            {
                var parameter = Expression.Parameter(typeof(TEntity), "e");
                Expression combined = null;

                foreach (var filter in filters)
                {
                    var property = Expression.Property(parameter, filter.PropertyName);
                    var value = Expression.Constant(Convert.ChangeType(filter.Value, property.Type));

                    Expression operation = filter.Operation switch
                    {
                        EnumOperationType.Equal => Expression.Equal(property, value),
                        EnumOperationType.NotEqual => Expression.NotEqual(property, value),
                        EnumOperationType.GreaterThan => Expression.GreaterThan(property, value),
                        EnumOperationType.LessThan => Expression.LessThan(property, value),
                        _ => throw new NotImplementedException()
                    };

                    combined = combined == null ? operation : Expression.AndAlso(combined, operation);
                }

                var lambda = Expression.Lambda<Func<TEntity, bool>>(combined, parameter);
                query = query.Where(lambda);
            }

            return await query.AsNoTracking()
                              .Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSetEntity.FindAsync(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSetEntity;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ICollection<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSetEntity;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSetEntity.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task<ICollection<TEntity>> GetWithPagination(Expression<Func<TEntity, bool>> predicate, int page = 1, int pageSize = 25, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSetEntity;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSetEntity.AsNoTracking().AnyAsync(predicate);
        }

        public virtual async Task Add(TEntity entity)
        {
            _dbSetEntity.Add(entity);
            await SaveChanges();
        }

        public virtual async Task AddRange(ICollection<TEntity> entity)
        {
            await _dbSetEntity.AddRangeAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSetEntity.Update(entity);
            await SaveChanges();
        }

        public virtual async Task UpdateRange(ICollection<TEntity> entities)
        {
            _dbSetEntity.UpdateRange(entities);
            await SaveChanges();

            _dbContext.ChangeTracker.Clear();
        }

        public virtual async Task Delete(Guid id)
        {
            var entity = await _dbSetEntity.FindAsync(id);

            _dbSetEntity.Remove(entity);
            await SaveChanges();
        }

        public virtual async Task DeleteRange(ICollection<Guid> ids)
        {
            var entities = await _dbSetEntity.FindAsync(ids);

            _dbSetEntity.RemoveRange(entities);
            await SaveChanges();
        }

        public async Task<int> TotalCount()
        {
            return await _dbSetEntity.CountAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
