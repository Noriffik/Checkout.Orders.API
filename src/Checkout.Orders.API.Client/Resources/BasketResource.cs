using System;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;

namespace Checkout.Orders.API.Client.Resources
{
    public class BasketResource : IBasketResource
    {
        private readonly IBaseClient _client;

        public BasketResource(IBaseClient client)
        {
            _client = client;
        }

        private Uri BuildUri(string path = "")
        {
            return _client.BuildUri(string.Format("api/basket", path));
        }

        private Uri BuildUri(Guid id, string path = "")
        {
            return _client.BuildUri(string.Format("api/basket/{0}/{1}", id, path));
        }

        public async Task<BasketResponseModel> Get(Guid id )
        {
            var uri = BuildUri(id);
            return await _client.GetAsync<BasketResponseModel>(uri);
        }
 
        public async Task<string> Create(CreateBasketRequest request)
        {
            var uri = BuildUri();
            return await _client.PostAsync(uri, request);
        }

        public  Task Delete(Guid id)
        {
            var uri = BuildUri(id);
            return  _client.DeleteAsync(uri);
        }

        public  Task RemoveAll(Guid basketId)
        {
            var uri = BuildUri(basketId, $"item");
            return _client.DeleteAsync(uri);
        }

    }
}
