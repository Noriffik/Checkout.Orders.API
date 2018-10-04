using System;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;

namespace Checkout.Orders.API.Client.Resources
{
    public interface IBasketResource
    {
        Task<string> Create(CreateBasketRequest request);
        Task Delete(Guid id);
        Task<BasketResponseModel> Get(Guid id);
        Task RemoveAll(Guid basketId);
    }
}