using System;

namespace Checkout.Orders.Domain.Messages.ItemsBasket
{
    public class GetItemBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
    }
}