using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.Infrastructure.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetRangeById(IEnumerable<int> ids);
        void Remove(TEntity entity);
        void RemoveById(int id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveRangeById(IEnumerable<int> ids);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entitites);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAll();
    }
}
