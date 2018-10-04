using System;
using System.Net.Http;
using Checkout.Orders.API.Client.Resources;

namespace Checkout.Orders.API.Client
{
   public class OrderApiClient : IOrderApiClient
    {
        public OrderApiClient(Uri baseUri)
        {
            SetupResources(baseUri.ToString());
        }
        public OrderApiClient(HttpClient client)
        {
            Basket = new BasketResource(new BaseClient(client, client.BaseAddress.ToString()));
            Item = new ItemResource(new BaseClient(client, client.BaseAddress.ToString()));
        }
        private void SetupResources(string baseUri)
        {
            Basket = new BasketResource(new BaseClient(new HttpClient(), baseUri ));
            Item = new ItemResource(new BaseClient(new HttpClient(), baseUri ));
        }


        public IBasketResource Basket { get; private set; }
        public IItemResource Item { get; private set; }
    }
}
