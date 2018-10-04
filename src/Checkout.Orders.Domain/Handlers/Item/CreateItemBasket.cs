using System;
using AutoMapper;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.ItemsBasket;
using Checkout.Orders.Domain.Repositories;

namespace Checkout.Orders.Domain.Handlers.Item
{
    public class CreateItemBasket : MessageHandler<CreateItemBasketMessage, IItem>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateItemBasket(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public override IItem Handle(CreateItemBasketMessage message)
        {
            var entity = _mapper.Map<IItem>(message);
            entity.ItemId = new Guid();
            return _basketRepository.AddItem(message.BasketId, entity);
        }
    }
}