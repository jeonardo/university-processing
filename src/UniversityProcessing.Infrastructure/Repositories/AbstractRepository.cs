using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniversityProcessing.Shared.Entities;

namespace UniversityProcessing.Infrastructure.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        protected readonly ApplicationDbContext db;
        protected readonly DbSet<T> entitiySet;

        public AbstractRepository(ApplicationDbContext dbContext)
        {
            db = dbContext;
            entitiySet = db.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await db.AddAsync(entity, cancellationToken);

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await db.AddRangeAsync(entities, cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await entitiySet.ToListAsync(cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await entitiySet.Where(expression).ToListAsync(cancellationToken);

        public async Task<T?> GetOrNullAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await entitiySet.FirstOrDefaultAsync(expression, cancellationToken);

        public void Remove(T entity)
            => db.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities)
            => db.RemoveRange(entities);

        public void Update(T entity)
            => db.Update(entity);

        public void UpdateRange(IEnumerable<T> entities)
            => db.UpdateRange(entities);
    }
}
