using System;
using System.Collections.Generic;
using System.Linq;
using Checkout.Orders.Domain.Entities;

namespace Checkout.Orders.Domain.Repositories
{
    public class MemoryBasketsRepository : IBasketRepository
    {
        public MemoryBasketsRepository()
        {
            //By default, some values
            _baskets = new List<IBasket>
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

        public MemoryBasketsRepository(IList<IBasket> baskets)
        {
            _baskets = baskets;
        }

        private IList<IBasket> _baskets { get; }

        public IList<IBasket> Get()
        {
            return _baskets.ToList();
        }

        public IBasket Get(Guid basketId)
        {
            return _baskets
                .FirstOrDefault(_ => _.BasketId == basketId);
        }

        public IList<IItem> GetItems(Guid basketId)
        {
            return _baskets
                .FirstOrDefault(_ => _.BasketId == basketId)
                ?.Items;
        }

        public IBasket Add(IBasket basket)
        {
            _baskets.Add(basket);
            return basket;
        }

        public IBasket Update(Guid basketId, IBasket basket)
        {
            var result = _baskets.FirstOrDefault(_ => _.BasketId == basketId);
            if (result == null) return new Basket();
            var index = _baskets.IndexOf(result);
            _baskets[index] = basket;

            return basket;
        }

        public IItem IncrementDecrementQuantity(Guid basketId, Guid itemId, int quantity)
        {
            return ChangeQuantity(basketId, itemId, item =>
            {
                item.Quantity = item.Quantity + quantity;
                return item;
            });
        }

        public IList<IItem>  RemoveAllItems(Guid basketId)
        {
            var target = _baskets.FirstOrDefault(r => r.BasketId == basketId);
            target.Items = new List<IItem>();
            Update(basketId, target);

            return target.Items;
        }

        public IBasket Delete(Guid basketId)
        {
            var target = _baskets.FirstOrDefault(r => r.BasketId == basketId);
            Update(basketId, target);

            return target;
        }

        public IItem GetItem(Guid basketId, Guid itemId)
        {
             return _baskets
                .FirstOrDefault(_ => _.BasketId == basketId)
                 ?.Items.FirstOrDefault(_=>_.ItemId==itemId);
        }

        public IItem RemoveItem(Guid basketId, Guid itemId)
        {
            var target = _baskets.FirstOrDefault(r => r.BasketId == basketId)?
                .Items.FirstOrDefault(_=>_.ItemId== itemId);
            _baskets.FirstOrDefault(r => r.BasketId == basketId)?.Items.Remove(target);

            target.Quantity = 0;
            return target;
        }

        public IItem AddItem(Guid basketId, IItem entity)
        {
           _baskets.FirstOrDefault(_=>_.BasketId == basketId)?.Items.Add(entity);
            return entity;
        }

        private IItem ChangeQuantity(Guid basketId, Guid itemId, Func<IItem, IItem> func)
        {
            var basket = Get(basketId);
            var item = basket.Items.FirstOrDefault(_ => _.ItemId == itemId);
            var index = basket.Items.IndexOf(item);
            basket.Items[index] = func.Invoke(item);

            return item;
        }
    }
}