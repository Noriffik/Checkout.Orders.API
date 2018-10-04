using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Basket
{
    public class GetBasket : IMessageHandler<GetBasketMessage, IBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public GetBasket(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public  IBasket Handle(GetBasketMessage message)
        {
            return _basketRepository.Get(message.BasketId);
        }
    }
}