using Checkout.Orders.API.Client.Resources;

namespace Checkout.Orders.API.Client
{
    public interface IOrderApiClient
    {
        IBasketResource Basket { get; }
    }
}