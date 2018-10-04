using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;

namespace Checkout.Orders.API.Client.Resources
{
    public class ItemResource : IItemResource
    {
        private readonly IBaseClient _client;

        public ItemResource(IBaseClient client)
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


        public async Task<IEnumerable<ItemResponseModel>> GetItems(Guid basketId)
        {
            var uri = BuildUri(basketId, "item");
            return await _client.GetAsync<IEnumerable<ItemResponseModel>>(uri);
        }

        public async Task<string> AddItem(Guid basketId, CreateItemBasketRequest request)
        {
            var uri = BuildUri(basketId, "item/");
            return await _client.PostAsync(uri, request);
        }

        public async Task<ItemResponseModel> IncreaseDecreaseItem(Guid basketId, Guid itemId, int quantity)
        {
            var uri = BuildUri(basketId, $"item/{itemId}");
            return await _client.PutAsync<ItemResponseModel>(uri, new IncreaseDecreaseItemRequest{Quantity = quantity});
        }
    }
}
