namespace Checkout.Orders.Domain.Mediator
{
    public interface IMediator
    {
        TResponse Send<TRequest, TResponse>(TRequest request);
    }
}