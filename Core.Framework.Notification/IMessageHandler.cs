namespace Core.Framework.Notification
{
    public interface IMessageHandler
    {
        void Send(INotificationMessage message);
        void Send(IMessageBuilder builder);
    }
}
