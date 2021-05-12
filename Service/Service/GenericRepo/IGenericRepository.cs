using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.GenericRepo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllEntities();
        Task<TEntity> GetByEntityID(int entityID);
        void AddEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
    }
}