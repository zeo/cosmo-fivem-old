using Cosmo.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cosmo.Utils
{
    public class HttpClient
    {
        private readonly System.Net.Http.HttpClient _client;

        public HttpClient(Config config)
        {
            _client = new System.Net.Http.HttpClient();
            _client.BaseAddress = new Uri(config.InstanceUrl + "/api/game");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.ServerToken);
        }

        public async Task<PendingOrdersExpiredActions> GetPendingOrdersAndExpiredActions()
        {
            var response = await _client.GetAsync("/store/pending");
            var data = await ParseResponse<PendingOrdersExpiredActions>(response);

            return data;
        }

        public async Task<bool> CompleteAction(ulong actionId)
        {
            var response = await _client.PutAsync("/store/actions/" + actionId + "/complete", null);
            
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> ExpireAction(ulong actionId)
        {
            var response = await _client.PutAsync("/store/actions/" + actionId + "/expire", null);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> DeliverOrder(ulong orderId)
        {
            var response = await _client.PutAsync("/store/orders/" + orderId + "/deliver", null);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        private async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}
