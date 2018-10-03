using System;
using System.Collections.Generic;
using Checkout.Orders.Domain.Entities;

namespace Checkout.Orders.Tests
{
    public  class Constants
    {
        public  Func<List<IBasket>> BASKET = ()=> new List<IBasket>
        {
            new Basket
            {
                Email = "test@test.com",
                BasketId = new Guid("42b3507c-08e4-4eb7-a5d5-cbef77486fbd"),
                Items = new List<IItem>
                {
                    new Item {ItemId = new Guid("42b3507c-08e4-4eb7-a5d5-cbef77486fbd"), Quantity = 1}
                }
            }
        };
    }
}