using System;
using Checkout.Orders.Domain.Handlers.Item;
using Checkout.Orders.Domain.Messages.ItemsBasket;
using Checkout.Orders.Domain.Repositories;
using Shouldly;
using Xunit;

namespace Checkout.Orders.Tests.Handlers
{
   public class IncrementDecrementHandlerTests
   {
       private readonly IncreaseDecreaseItem _sut;

       public IncrementDecrementHandlerTests()
       {
           _sut =  new IncreaseDecreaseItem(new MemoryBasketsRepository(new Constants().BASKET()));
       }


       [Theory]
       [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
       public void Quantity_Should_Increase(string id)
       {
          var result = _sut.Handle(new IncreaseDeacreaseItemMessage {BasketId = new Guid(id), ItemId = new Guid(id), Quantity = 5});

           result.Quantity.ShouldBe(6);
       }

       [Theory]
       [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
       public void Quantity_Should_Decrease(string id)
       {
           var sut = new IncreaseDecreaseItem(new MemoryBasketsRepository(new Constants().BASKET()));
           var result = sut.Handle(new IncreaseDeacreaseItemMessage {BasketId = new Guid(id), ItemId = new Guid(id), Quantity = -1});

           result.Quantity.ShouldBe(0);
       }

       [Theory]
       [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
       public void Quantity_Must_NOT_Be_Negative(string id)
       {
           var result = _sut.Handle(new IncreaseDeacreaseItemMessage {BasketId = new Guid(id), ItemId = new Guid(id), Quantity = -99});

           result.Quantity.ShouldBe(0);
       }
   }
}
