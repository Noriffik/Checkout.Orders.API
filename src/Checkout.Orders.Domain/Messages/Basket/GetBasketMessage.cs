using System;

namespace Checkout.Orders.Domain.Messages.Basket
{
    public class GetBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
    }
}