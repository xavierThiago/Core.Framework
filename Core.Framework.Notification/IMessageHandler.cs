using System.Threading.Tasks;

namespace Core.Framework.Notification
{
    public interface IMessageHandler
    {
        void Send<T>(INotificationMessage<T> message)
            where T : MessageContact;
        void Send(IMessageBuilder builder);

        Task SendAsync<T>(INotificationMessage<T> message)
            where T : MessageContact;
        Task SendAsync(IMessageBuilder builder);
    }
}
