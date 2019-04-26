using System.Threading;
using System.Threading.Tasks;

namespace Core.Framework.Cqrs.Queries
{
    public interface IQueryHandlerAsync<T, R>
        where T : class, IFilter
        where R : class
    {
        Task<R> HandleAsync(T filter, CancellationToken cancellationToken = default);
    }
}
