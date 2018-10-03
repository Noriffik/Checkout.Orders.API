using Checkout.Orders.API;
using Checkout.Orders.Domain.Mediator;
using Checkout.Orders.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Orders.Tests.Factory
{
    public class ApiApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
           builder.ConfigureServices(services =>
           {
               var sp = services
                   .AddScoped<IMediator, Mediator>()
                   .AddSingleton<IBasketRepository>(provider=> new MemoryBasketsRepository(new Constants().BASKET()))
                   .AddHandlers()
                   .AddMapper()
                   .BuildServiceProvider();
           });
        }
    }
}