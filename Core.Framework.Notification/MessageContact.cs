namespace Core.Framework.Notification
{
    public sealed class MessageContact
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public MessageContact(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
