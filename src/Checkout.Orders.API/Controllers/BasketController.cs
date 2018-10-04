using System;
using System.Collections.Generic;
using AutoMapper;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;
using Checkout.Orders.API.Infrastructure.Filters;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Mediator;
using Checkout.Orders.Domain.Messages.Basket;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Orders.API.Controllers
{
    [Route("api/basket")]
    [ApiExceptionFilter]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result =  _mediator.Send<ListBasketMessage, IList<IBasket>>(new ListBasketMessage());
            return Ok(_mapper.Map<IList<BasketResponseModel>>(result));
        }

        [HttpGet("{basketId:guid}")]
        [BasketExists]
        public IActionResult GetById(Guid basketId)
        {
            var getMessage = new GetBasketMessage { BasketId = basketId };
            var result = _mediator.Send<GetBasketMessage, IBasket>(getMessage);
            return Ok(_mapper.Map<BasketResponseModel>(result));
        }

        [HttpPost]
        public IActionResult Post(CreateBasketRequest request)
        {
            var createMessage = _mapper.Map<CreateBasketMessage>(request);
            var result = _mediator.Send<CreateBasketMessage, IBasket>(createMessage);

            return CreatedAtAction(nameof(GetById), new { basketId = result.BasketId }, null);
        }

        [HttpDelete("{basketId:guid}")]
        [BasketExists]
        public IActionResult Delete(Guid basketId)
        {
            var deleteMessage = new DeleteBasketMessage { BasketId = basketId };
            _mediator.Send<DeleteBasketMessage, IBasket>(deleteMessage);

            return NoContent();
        }
    }
}