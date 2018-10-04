using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.ItemsBasket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Item
{
    public class IncreaseDecreaseItem : MessageHandler<IncreaseDeacreaseItemMessage, IItem>
    {
        private readonly IBasketRepository _basketRepository;

        public IncreaseDecreaseItem(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public override IItem Handle(IncreaseDeacreaseItemMessage itemMessage)
        {
            if (itemMessage.Quantity > 0)
            {
                return _basketRepository.IncrementDecrementQuantity(itemMessage.BasketId, itemMessage.ItemId, itemMessage.Quantity);
            }

            var item = _basketRepository.GetItem(itemMessage.BasketId, itemMessage.ItemId);

            return item.Quantity <= -(itemMessage.Quantity) ? 
                _basketRepository.RemoveItem(itemMessage.ItemId, itemMessage.BasketId) :
                _basketRepository.IncrementDecrementQuantity(itemMessage.BasketId, itemMessage.ItemId, itemMessage.Quantity);
        }
    }
}