using System.Threading;
using System.Threading.Tasks;

namespace Core.Framework.Cqrs.Commands
{
    public interface ICommandHandlerAsync<T>
        where T : class, ICommand
    {
        Task ExecuteAsync(T command, CancellationToken cancellationToken = default);
    }

    public interface ICommandHandlerAsync<T, TResult>
        where T : class, ICommand
        where TResult : class
    {
        Task<TResult> ExecuteAsync(T command, CancellationToken cancellationToken = default);
    }
}
