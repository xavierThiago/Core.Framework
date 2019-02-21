namespace Core.Framework.Notification
{
    public interface IMessageBuilder
    {
        INotificationMessage Build(IMessageParser parser = null);
    }
}
