using System.Threading.Tasks;

namespace Core.Framework.Notification
{
    public interface IMessageHandler<T>
        where T : MessageContact
    {
        void Send(INotificationMessage<T> message);
        void Send(IMessageBuilder<T> builder);

        Task SendAsync(INotificationMessage<T> message);
        Task SendAsync(IMessageBuilder<T> builder);
    }
}
