using System;
using System.Threading.Tasks;
using Checkout.Orders.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Checkout.Orders.API.Infrastructure.Filters
{
    public class BasketExistsAttribute : TypeFilterAttribute
    {
        public BasketExistsAttribute() : base(typeof
            (BasketExistsFilterImpl))
        {
        }

        private class BasketExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IBasketRepository _basketsRepository;

            public BasketExistsFilterImpl(IBasketRepository basketsRepository)
            {
                _basketsRepository = basketsRepository;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context,
                ActionExecutionDelegate next)
            {
                if (!context.ActionArguments.ContainsKey("basketId"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if (!(context.ActionArguments["basketId"] is Guid id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = _basketsRepository.Get(id);

                if (result == null)
                {
                    context.Result = new NotFoundObjectResult(new {Message = $"Item with id {id} not exist."});
                    return;
                }

                await next();
            }
        }
    }
}