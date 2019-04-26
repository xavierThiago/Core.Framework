namespace Core.Framework.Cqrs.Queries
{
    public interface IQueryHandler<T, R>
        where T : class, IFilter
        where R : class
    {
        R Handle(T filter);
    }
}
