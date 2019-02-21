using System.Collections.Generic;

namespace Core.Framework.Notification
{
    public interface INotificationMessage
    {
        MessageContact From { get; set; }
        List<MessageContact> To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
    }
}
