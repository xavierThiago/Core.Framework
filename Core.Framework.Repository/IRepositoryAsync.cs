using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Framework.Entities;

namespace Core.Framework.Repository
{
    public interface IRepositoryAsync<T> : IDisposable
        where T : class, IDbObject
    {
        IQueryable<T> Get(Func<T, bool> predicate = null);
        Task<T> FindAsync(params object[] keys);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task SaveAsync();
        void Rollback();
    }
}
