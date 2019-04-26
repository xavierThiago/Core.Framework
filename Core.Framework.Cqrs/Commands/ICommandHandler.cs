namespace Core.Framework.Cqrs.Commands
{
    public interface ICommandHandler<T>
        where T : class, ICommand
    {
        void Execute(T command);
    }

    public interface ICommandHandler<T, R>
        where T : class, ICommand
        where R : class
    {
        R Execute(T command);
    }
}
