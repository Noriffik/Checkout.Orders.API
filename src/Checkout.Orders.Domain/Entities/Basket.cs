using System;
using System.Collections.Generic;

namespace Checkout.Orders.Domain.Entities
{
    public class Basket : IBasket
    {
        public Guid BasketId { get; set; }
        public IList<IItem> Items { get; set; } = new List<IItem>();
        public string Email { get; set; }
        public Money Total => new Money();
    }
}