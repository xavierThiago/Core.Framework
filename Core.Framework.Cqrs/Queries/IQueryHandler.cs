namespace Core.Framework.Cqrs.Queries
{
    public interface IQueryHandler<T, TResult>
        where T : class, IFilter
        where TResult : class
    {
        TResult Handle(T filter);
    }
}
