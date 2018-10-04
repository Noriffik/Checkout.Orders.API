using AutoMapper;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Messages.ItemsBasket;

namespace Checkout.Orders.API.Infrastructure.Mapper
{
    public class MapperDefinitions : Profile
    {
        public MapperDefinitions()
        {
            CreateMap<IBasket, BasketResponseModel>().ReverseMap();
            CreateMap<IItem, ItemResponseModel>().ReverseMap();

            CreateMap<CreateBasketMessage, CreateBasketRequest>().ReverseMap();
            CreateMap<UpdateBasketMessage, UpdateBasketRequest>().ReverseMap();
            CreateMap<CreateItemBasketMessage, CreateItemBasketRequest >().ReverseMap();
            CreateMap<IncreaseDeacreaseItemMessage, IncreaseDecreaseItemRequest >().ReverseMap();
        }
    }
}