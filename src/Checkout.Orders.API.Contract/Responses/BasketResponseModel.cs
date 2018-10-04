using System;
using System.Collections.Generic;

namespace Checkout.Orders.API.Contract.Responses
{
    public class BasketResponseModel  
    {
        public Guid BasketId { get; set; }
        public IList<ItemResponseModel> Items { get; set; }
        public string Email { get; set; }
        public Money Total { get; set; } = new Money();
    }
}