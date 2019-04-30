using System;

namespace Core.Framework.SendGrid.Broadcast.Domain
{
    public class BroadcastList
    {
        public string Name { get; set; }

        public BroadcastList(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
