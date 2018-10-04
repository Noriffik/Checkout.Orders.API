using System;
using System.Threading.Tasks;
using Checkout.Orders.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Checkout.Orders.API.Infrastructure.Filters
{
    public class ItemExistsAttribute : TypeFilterAttribute
    {
        public ItemExistsAttribute() : base(typeof
            (ItemExistsFilterImpl))
        {
        }

        private class ItemExistsFilterImpl : IAsyncActionFilter
        {
            private readonly IBasketRepository _basketsRepository;

            public ItemExistsFilterImpl(IBasketRepository basketsRepository)
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

                if (!context.ActionArguments.ContainsKey("itemId"))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if (!(context.ActionArguments["basketId"] is Guid basketId))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                if (!(context.ActionArguments["itemId"] is Guid itemId))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = _basketsRepository.GetItem(basketId,itemId);

                if (result == null)
                {
                    context.Result = new NotFoundObjectResult(new {Message = $"Item with id {itemId} not exist."});
                    return;
                }



                await next();
            }
        }
    }
}