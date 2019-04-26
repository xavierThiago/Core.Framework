using System.Threading;
using System.Threading.Tasks;

namespace Core.Framework.Cqrs.Commands
{
    public interface ICommandHandlerAsync<T>
        where T : class, ICommand
    {
        Task ExecuteAsync(T command, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandlerAsync<T, R>
        where T : class, ICommand
        where R : class
    {
        Task<R> ExecuteAsync(T command, CancellationToken cancellationToken = default);
    }
}
