using AutoMapper;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Basket
{
    public class UpdateBasket : MessageHandler<UpdateBasketMessage, IBasket>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public UpdateBasket(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public override IBasket Handle(UpdateBasketMessage message)
        {
            return _basketRepository.Update(message.BasketId, _mapper.Map<IBasket>(message));
        }
    }
}