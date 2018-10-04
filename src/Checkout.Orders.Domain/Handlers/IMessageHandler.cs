namespace Checkout.Orders.Domain.Handlers
{
    public interface IMessageHandler<T, TG>
    {
        TG Handle(T message);
    }
}