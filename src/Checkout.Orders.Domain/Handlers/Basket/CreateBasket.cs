using System;
using AutoMapper;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Basket
{
    public class CreateBasket : MessageHandler<CreateBasketMessage, IBasket>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateBasket(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public override IBasket Handle(CreateBasketMessage message)
        {
            message.BasketId = Guid.NewGuid();
            return _basketRepository.Add(_mapper.Map<IBasket>(message));
        }
    }
}