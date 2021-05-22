using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperService.Infrastructure
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllEntities();
        Task<T> GetEntityById(int id);
        Task<T> CreateEntity(T entity);
        Task<int> UpdateEntity(T entity);
        Task<int> DeleteEntity(int id);
    }
}
