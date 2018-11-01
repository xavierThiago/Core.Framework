using System;
using System.Linq;
using Core.Framework.Entities;

namespace Core.Framework.Repository
{
    public interface IRepository<T> : IDisposable
        where T : class, IEntity
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Func<T, bool> predicate);
        T Find(params object[] keys);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Remove(Func<T, bool> predicate);
        void Save();
    }
}
