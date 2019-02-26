namespace Core.Framework.Notification
{
    public interface IMessageBuilder<T>
        where T : MessageContact
    {
        INotificationMessage<T> Build(IMessageParser parser = null);
    }
}
