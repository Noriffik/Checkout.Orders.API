using System;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;

namespace Checkout.Orders.API.Client
{
    public interface IBaseClient
    {
        Task<T> GetAsync<T>(Uri uri);
        Task<string> PostAsync(Uri uri, object request);
        Task<string> PostAsync(Uri uri);
        Task DeleteAsync(Uri uri);
        Uri BuildUri(string format);
        Task<T> PutAsync<T>(Uri uri, IncreaseDecreaseItemRequest increaseDecreaseItemRequest);
    }
}