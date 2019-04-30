using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Framework.SendGrid.Recipients.Domain;
using Newtonsoft.Json;

namespace Core.Framework.SendGrid.Recipients
{
    public class RecipientService : IRecipientService
    {
        readonly HttpClient _httpClient;

        public RecipientService()
        {
            _httpClient = SendGridHttpConfiguration.GetSendGridHttpClient();
        }

        public async Task<string> CreateAsync(Recipient recipient, CancellationToken cancellationToken = default)
        {
            List<Recipient> recipients = new List<Recipient>
            {
                recipient
            };

            return await CreateAsync(recipients, cancellationToken);
        }

        public async Task<string> CreateAsync(List<Recipient> recipients, CancellationToken cancellationToken = default)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "v3/contactdb/recipients")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(recipients), Encoding.UTF8, "application/json")
                };

                var response = await _httpClient.SendAsync(request, cancellationToken);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
