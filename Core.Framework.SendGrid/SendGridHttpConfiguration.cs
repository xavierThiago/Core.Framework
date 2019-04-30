using System;
using System.Net.Http;

namespace Core.Framework.SendGrid
{
    internal static class SendGridHttpConfiguration
    {
        static HttpClient _httpClientFactory;

        internal static HttpClient GetSendGridHttpClient()
        {
            if (_httpClientFactory != null) return _httpClientFactory;

            var key =
                SendGridConfiguration.SendGridKey ?? throw new ArgumentNullException(nameof(SendGridConfiguration.SendGridKey));

            _httpClientFactory = new HttpClient
            {
                BaseAddress = new Uri("https://api.sendgrid.com")
            };
            _httpClientFactory.DefaultRequestHeaders.Add(
                "Authorization", $"Bearer {key}");

            return _httpClientFactory;
        }
    }
}
