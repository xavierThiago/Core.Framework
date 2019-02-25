namespace Core.Framework.Notification
{
    public interface IMessageBuilder
    {
        INotificationMessage<T> Build<T>(IMessageParser parser = null)
            where T : MessageContact;
    }
}
