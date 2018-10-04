using System.Collections.Generic;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Basket
{
    public class ListBasket : MessageHandler<ListBasketMessage, IList<IBasket>>
    {
        private readonly IBasketRepository _basketRepository;

        public ListBasket(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public override IList<IBasket> Handle(ListBasketMessage message)
        {
            return _basketRepository.Get();
        }
    }
}