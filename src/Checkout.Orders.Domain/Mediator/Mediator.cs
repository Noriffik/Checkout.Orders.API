using System;
using Checkout.Orders.Domain.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Checkout.Orders.Domain.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public TResponse Send<TRequest, TResponse>(TRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var handler =
                (IMessageHandler<TRequest, TResponse>) _serviceProvider.GetRequiredService(
                    typeof(IMessageHandler<TRequest, TResponse>));

            return handler.Handle(request);
        }
    }
}