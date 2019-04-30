using System;
using Newtonsoft.Json;

namespace Core.Framework.SendGrid.Recipients.Domain
{
    public class Recipient
    {
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        public Recipient(string email)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public string GetName()
        {
            return string.Join(' ', FirstName, LastName);
        }
    }
}
