namespace Core.Framework.API.Messages
{
    public abstract class PagedBaseRequest : BaseRequest
    {
        public int Page
        { get; set; } = 0;

        public int PageSize
        { get; set; } = 10;
    }
}
