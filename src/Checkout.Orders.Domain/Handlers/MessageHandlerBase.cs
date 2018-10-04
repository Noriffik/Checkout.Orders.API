using Checkout.Orders.Domain.Messages;

namespace Checkout.Orders.Domain.Handlers
{
    public abstract class MessageHandler<TRequest, TResponse> : IMessageHandler<TRequest, TResponse>
        where TRequest : IMessage

    {
        public virtual TResponse Handle(TRequest message)
        {
            return (TResponse) new object();
        }
    }
}