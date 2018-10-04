using System.Collections.Generic;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.ItemsBasket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Item
{
    public class GetItemBasket : IMessageHandler<GetItemBasketMessage, IList<IItem>>
    {
        private readonly IBasketRepository _basketRepository;

        public GetItemBasket(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public  IList<IItem> Handle(GetItemBasketMessage message)
        {
            return _basketRepository.GetItems(message.BasketId);
        }
    }
}