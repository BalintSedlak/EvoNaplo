using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.Infrastructure.DataAccessLayer
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly EvoNaploContext _context;

        public Repository(EvoNaploContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void RemoveById(int id)
        {
            TEntity entity = _context.Set<TEntity>().Single(x => x.Id == id);
            _context.Set<TEntity>().Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRangeById(IEnumerable<int> ids)
        {
            IEnumerable<TEntity> entities = _context.Set<TEntity>().Where(x => ids.ToList().Contains(x.Id));
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entitites)
        {
            _context.Set<TEntity>().UpdateRange(entitites);
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Single(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetRangeById(IEnumerable<int> ids)
        {
            IEnumerable<TEntity> entities = _context.Set<TEntity>().Where(x => ids.ToList().Contains(x.Id));
            return entities;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }        
    }
}
