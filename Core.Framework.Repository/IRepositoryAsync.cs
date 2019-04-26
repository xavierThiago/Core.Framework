using System.Threading.Tasks;
using Core.Framework.Entities;

namespace Core.Framework.Repository
{
    public interface IRepositoryAsync<T> : IRepository<T>
        where T : class, IDbObject
    {
        Task<T> FindAsync(params object[] keys);
        Task AddAsync(T entity);
        Task SaveAsync();
    }
}
