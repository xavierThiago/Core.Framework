namespace Core.Framework.Cqrs.Queries
{
    public interface IPagedFilter : IFilter
    {
        int Page { get; set; }
        int PageSize { get; set; }
    }
}
