using System;
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
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TEntity> GetByEntityID(int entityID)
        {
            try
            {
                return await _dbSet.FindAsync();
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError(typeof(TEntity).ToString() + " entity with id " + entityID + " is not found.");
                throw;
            }
        }

        public TEntity AddEntity(TEntity entity)
        {
            try
            {
                return _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Fail to add " + typeof(TEntity).ToString() + " entity.");
                throw;
            }
        }

        public TEntity UpdateEntity(TEntity entity)
        {
            try {
                TEntity e = _dbSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;

                return e;
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Fail to update " + typeof(TEntity).ToString() + " entity.");
                throw;
            }
        }

        public TEntity DeleteEntity(TEntity entity)
        {
            try {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                return _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                Logger.Logger.LogError("Fail to delete " + typeof(TEntity).ToString() + " entity.");
                throw;
            }
        }
    }
}
