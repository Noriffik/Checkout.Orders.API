using System;
using System.Collections.Generic;
using Checkout.Orders.Domain.Entities;

namespace Checkout.Orders.Domain.Repositories
{
    public interface IBasketRepository
    {
        IList<IBasket> Get();
        IBasket Get(Guid basketId);
        IList<IItem> GetItems(Guid basketId);
        IBasket Add(IBasket basket);
        IBasket Update(Guid basketId, IBasket basket);
        IItem IncrementDecrementQuantity(Guid basketId, Guid itemId, int quantity);
        IList<IItem> RemoveAllItems(Guid basketId);
        IBasket Delete(Guid basketId);
        IItem GetItem(Guid basketId, Guid itemId);
        IItem RemoveItem(Guid basketId, Guid itemId);
        IItem AddItem(Guid basketId, IItem entity);
    }
}