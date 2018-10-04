using System.Collections.Generic;
using AutoMapper;
using Checkout.Orders.API.Infrastructure.Mapper;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Handlers;
using Checkout.Orders.Domain.Handlers.Basket;
using Checkout.Orders.Domain.Handlers.Item;
using Checkout.Orders.Domain.Messages.Basket;
using Checkout.Orders.Domain.Messages.ItemsBasket;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection _)
        {
            _.AddTransient<IMessageHandler<CreateBasketMessage, IBasket>, CreateBasket>();
            _.AddTransient<IMessageHandler<ListBasketMessage, IList<IBasket>>, ListBasket>();
            _.AddTransient<IMessageHandler<GetBasketMessage, IBasket>, GetBasket>();
            _.AddTransient<IMessageHandler<UpdateBasketMessage, IBasket>, UpdateBasket>();
            _.AddTransient<IMessageHandler<DeleteBasketMessage, IBasket>, DeleteBasket>();

            _.AddTransient<IMessageHandler<GetItemBasketMessage, IList<IItem>>, GetItemBasket>();
            _.AddTransient<IMessageHandler<CreateItemBasketMessage, IItem>, CreateItemBasket>();
            _.AddTransient<IMessageHandler<IncreaseDeacreaseItemMessage, IItem>, IncreaseDecreaseItem>();
            _.AddTransient<IMessageHandler<RemoveAllItemBasketMessage, IList<IItem>>, RemoveAllItemsBasket>();
            return _;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<MapperDefinitions>();
                c.AddProfile<Checkout.Orders.Domain.Infrastructure.Mapper.MapperDefinitions>();
            });
            services.AddSingleton(s => config.CreateMapper());
            return services;
        }
    }
}