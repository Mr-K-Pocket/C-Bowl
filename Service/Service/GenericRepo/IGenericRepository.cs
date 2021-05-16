using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.GenericRepo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllEntities();
        Task<TEntity> GetByEntityID(int entityID);
        TEntity AddEntity(TEntity entity);
        TEntity UpdateEntity(TEntity entity);
        TEntity DeleteEntity(TEntity entity);
    }
}