using System;

namespace Checkout.Orders.Domain.Messages.ItemsBasket
{
    public class IncreaseDeacreaseItemMessage : IMessage
    {
        public Guid BasketId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}