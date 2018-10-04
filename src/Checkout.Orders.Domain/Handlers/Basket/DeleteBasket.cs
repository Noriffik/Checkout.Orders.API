using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Basket
{
    public class DeleteBasket : MessageHandler<DeleteBasketMessage, IBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public DeleteBasket(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public override IBasket Handle(DeleteBasketMessage message)
        {
            return _basketRepository.Delete(message.BasketId);
        }
    }
}