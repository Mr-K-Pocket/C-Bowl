using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Service.GenericRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> _dbSet;
        private DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllEntities()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByEntityID(int entityID)
        {
            return await _dbSet.FindAsync();
        }

        public void AddEntity(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void UpdateEntity(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteEntity(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }
    }
}
