using System.Collections.Generic;

namespace Core.Framework.Notification
{
    public interface INotificationMessage<T>
        where T : MessageContact
    {
        T From { get; set; }
        List<T> To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
    }
}
