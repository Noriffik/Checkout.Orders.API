using System;

namespace Checkout.Orders.Domain.Entities
{
    public interface IItem
    {
        Guid ItemId { get; set; }
        string ItemCode { get; set; }
        string ItemDescription { get; set; }
        int Quantity { get; set; }
        Money Price { get; set; }
    }
}