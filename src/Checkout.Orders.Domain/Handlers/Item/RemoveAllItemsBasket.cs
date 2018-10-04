using System.Collections.Generic;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.ItemsBasket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Item
{
    public class RemoveAllItemsBasket : MessageHandler<RemoveAllItemBasketMessage, IList<IItem>>
    {
        private readonly IBasketRepository _basketRepository;

        public RemoveAllItemsBasket(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public override IList<IItem> Handle(RemoveAllItemBasketMessage message)
        {
            return _basketRepository.RemoveAllItems(message.BasketId);
        }
    }
}