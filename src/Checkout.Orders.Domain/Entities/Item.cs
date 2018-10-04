using System;

namespace Checkout.Orders.Domain.Entities
{
    public class Item : IItem
    {
        public Guid ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public Money Price { get; set; } = new Money();
    }
}