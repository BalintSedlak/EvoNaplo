using Microsoft.EntityFrameworkCore;

namespace EvoNaplo.Common.DataAccessLayer
{
    public class Repository<TEntity> : DbContext, IRepository<TEntity> where TEntity : class, IEntity
    {
        public Repository(DbContextOptions<Repository<TEntity>> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Repository");
            base.OnModelCreating(modelBuilder);
        }

        public void Add(TEntity entity)
        {
            this.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Set<TEntity>().AddRange(entities);
        }

        public void RemoveById(int id)
        {
            TEntity entity = this.Set<TEntity>().Single(x => x.Id == id);
            this.Set<TEntity>().Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            this.Set<TEntity>().Remove(entity);
        }

        public void RemoveRangeById(IEnumerable<int> ids)
        {
            IEnumerable<TEntity> entities = this.Set<TEntity>().Where(x => ids.ToList().Contains(x.Id));
            this.Set<TEntity>().RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            this.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entitites)
        {
            this.Set<TEntity>().UpdateRange(entitites);
        }

        public TEntity GetById(int id)
        {
            return this.Set<TEntity>().Single(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetRangeById(IEnumerable<int> ids)
        {
            IEnumerable<TEntity> entities = this.Set<TEntity>().Where(x => ids.ToList().Contains(x.Id));
            return entities;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.GetAll();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await this.SaveChangesAsync(cancellationToken);
        }        
    }
}
