using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Framework.SendGrid.Broadcast.Domain;
using Newtonsoft.Json;

namespace Core.Framework.SendGrid.Broadcast
{
    public class BroadcastService : IBroadcastService
    {
        readonly HttpClient _httpClient;

        public BroadcastService()
        {
            _httpClient = SendGridHttpConfiguration.GetSendGridHttpClient();
        }

        public async Task<string> CreateAsync(BroadcastList broadcastList, CancellationToken cancellationToken = default)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "v3/contactdb/lists")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(broadcastList), Encoding.UTF8, "application/json")
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
