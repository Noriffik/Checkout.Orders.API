using AutoMapper;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Messages.ItemsBasket;

namespace Checkout.Orders.Domain.Infrastructure.Mapper
{
    public class MapperDefinitions : Profile
    {
        public MapperDefinitions()
        {
            CreateMap<IBasket, CreateBasketMessage>().ReverseMap();
            CreateMap<IBasket, UpdateBasketMessage>().ReverseMap();
            CreateMap<IBasket, DeleteBasketMessage>().ReverseMap();

            CreateMap<IItem, CreateItemBasketMessage>().ReverseMap();
        }
    }
}