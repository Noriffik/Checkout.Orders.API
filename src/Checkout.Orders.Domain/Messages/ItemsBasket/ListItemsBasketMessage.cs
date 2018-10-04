using System;

namespace Checkout.Orders.Domain.Messages.ItemsBasket
{
    public class ListItemsBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
    }
}