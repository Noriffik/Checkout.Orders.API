using System;

namespace Checkout.Orders.Domain.Messages.ItemsBasket
{
    public class RemoveItemBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
        public Guid ItemId { get; set; }
    }
}