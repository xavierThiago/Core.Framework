using System;
using System.Linq;
using Core.Framework.Entities;

namespace Core.Framework.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class, IDbObject
    {
        IQueryable<T> Get(Func<T, bool> predicate = null);
        T Find(params object[] keys);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Save();
        void Rollback();
    }
}
