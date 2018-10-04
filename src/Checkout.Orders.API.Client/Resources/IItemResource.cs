using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;

namespace Checkout.Orders.API.Client.Resources
{
    public interface IItemResource
    {
        Task<string> AddItem(Guid basketId, CreateItemBasketRequest request);
        Task<IEnumerable<ItemResponseModel>> GetItems(Guid basketId);
        Task<ItemResponseModel> IncreaseDecreaseItem(Guid basketId, Guid itemId, int quantity);
    }
}