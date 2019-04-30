using System;

namespace Core.Framework.SendGrid
{
    public static class SendGridConfiguration
    {
        internal static string SendGridKey = string.Empty;

        public static void Configure(string key)
        {
            SendGridKey = key ?? throw new ArgumentNullException(nameof(key));
        }
    }
}
