using System;

namespace Checkout.Orders.API.Contract.Responses
{
    public class ItemResponseModel 
    {
        public Guid ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public Money Price { get; set; } = new Money();
    }
}