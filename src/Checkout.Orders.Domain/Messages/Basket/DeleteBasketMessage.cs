using System;

namespace Checkout.Orders.Domain.Messages.Basket
{
    public class DeleteBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
    }
}