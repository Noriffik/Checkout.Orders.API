using System;
using System.Collections.Generic;

namespace Checkout.Orders.Domain.Entities
{
    public interface IBasket
    {
        Guid BasketId { get; set; }
        IList<IItem> Items { get; set; }
        string Email { get; set; }
        Money Total { get; }
    }
}