namespace Core.Framework.Docs
{
    public interface IDoc
    {
        string Title
        { get; set; }

        string Content
        { get; set; }

        string Generate();
    }
}
