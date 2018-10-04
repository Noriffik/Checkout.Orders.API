using System;
using Checkout.Orders.Domain.Entities;

namespace Checkout.Orders.Domain.Messages.ItemsBasket
{
    public class CreateItemBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
        public Guid ItemId { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public Money Price { get; set; } = new Money();
    }
}