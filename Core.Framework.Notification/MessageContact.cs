namespace Core.Framework.Notification
{
    public abstract class MessageContact
    {
        public string Name { get; set; }

        protected MessageContact(string name)
        {
            Name = name;
        }
    }
}
