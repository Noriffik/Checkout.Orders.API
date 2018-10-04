using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;
using Newtonsoft.Json;

namespace Checkout.Orders.API.Client
{
    public class BaseClient : IBaseClient
    {
        public readonly HttpClient Client;
        public readonly string BaseUri;

        public BaseClient(HttpClient client, string baseUri)
        {
            Client = client;
            BaseUri = baseUri;
        }


        public async Task<T> GetAsync<T>(Uri uri)
        {

            var result = await Client.GetAsync(uri);
            result.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
        }

        public async Task<string> PostAsync(Uri uri, object request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var result = await Client.PostAsync(uri, content);
            result.EnsureSuccessStatusCode();
            return result.Headers.Location.ToString();
        }


        public async Task<string> PostAsync(Uri uri)
        {
           return await PostAsync(uri, new {});
        }

        public async Task DeleteAsync(Uri uri)
        {
            var result = await Client.DeleteAsync(uri);
            result.EnsureSuccessStatusCode();
        }

        public Uri BuildUri(string format)
        {
            return new UriBuilder(BaseUri)
            {
                Path = format
            }.Uri;
        }

        public async Task<T> PutAsync<T>(Uri uri, IncreaseDecreaseItemRequest increaseDecreaseItemRequest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(increaseDecreaseItemRequest), Encoding.UTF8, "application/json");
            var result = await Client.PutAsync(uri,content);
            result.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
        }
    }
}