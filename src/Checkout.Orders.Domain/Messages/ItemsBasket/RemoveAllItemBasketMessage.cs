using System;

namespace Checkout.Orders.Domain.Messages.ItemsBasket
{
    public class RemoveAllItemBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
    }
}