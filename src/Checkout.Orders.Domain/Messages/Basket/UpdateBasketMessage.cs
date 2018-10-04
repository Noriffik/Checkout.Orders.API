using System;
using System.Collections.Generic;
using Checkout.Orders.Domain.Entities;

namespace Checkout.Orders.Domain.Messages.Basket
{
    public class UpdateBasketMessage : IMessage
    {
        public Guid BasketId { get; set; }
        public ICollection<IItem> Items { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
    }
}