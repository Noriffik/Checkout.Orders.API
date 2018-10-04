using System;
using System.Collections.Generic;
using AutoMapper;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;
using Checkout.Orders.API.Infrastructure.Filters;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Mediator;
using Checkout.Orders.Domain.Messages.ItemsBasket;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Orders.API.Controllers
{
    [Route("api/basket/{basketId:guid}")]
    [ApiExceptionFilter]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BasketItemController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("item")]
        [BasketExists]
        public IActionResult Get(Guid basketId)
        {
            var result = _mediator.Send<GetItemBasketMessage, IList<IItem>>(new GetItemBasketMessage
                {BasketId = basketId});
            return Ok(_mapper.Map<IList<ItemResponseModel>>(result));
        }

        [HttpPost("item")]
        [BasketExists]
        public IActionResult CreateItem(Guid basketId, CreateItemBasketRequest request)
        {
            var message = _mapper.Map<CreateItemBasketMessage>(request);
            message.BasketId = basketId;

            _mediator.Send<CreateItemBasketMessage, IItem>(message);

            return CreatedAtAction(nameof(Get), new {basketId = message.BasketId}, null);
        }

        [HttpPut("item/{itemId:guid}")]
        [ItemExists]
        public IActionResult IncrementDecrement(Guid basketId, Guid itemId, IncreaseDecreaseItemRequest request)
        {
            var message = _mapper.Map<IncreaseDeacreaseItemMessage>(request);

            message.BasketId = basketId;
            message.ItemId = itemId;
            var result = _mediator.Send<IncreaseDeacreaseItemMessage, IItem>(message);

            return Ok(_mapper.Map<ItemResponseModel>(result));
        }


        [HttpDelete("item")]
        [BasketExists]
        public IActionResult Remove(Guid basketId)
        {
            var request = new RemoveAllItemBasketMessage {BasketId = basketId};
            _mediator.Send<RemoveAllItemBasketMessage, IList<IItem>>(request);

            return NoContent();
        }
    }
}