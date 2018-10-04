using System;
using System.Linq;
using Checkout.Orders.Domain.Entities;
using Checkout.Orders.Domain.Repositories;
using Shouldly;
using Xunit;

namespace Checkout.Orders.Tests.Repository
{
    public class MemoryOrdersRepositoryTests
    {
        private readonly IBasketRepository _sut;

        public MemoryOrdersRepositoryTests()
        {
            _sut = new MemoryBasketsRepository(new Constants().BASKET());
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void Get_Should_Retrieve_Data(string id)
        {
            _sut.Get(new Guid(id))
                .Items
                .Count.ShouldBe(1);
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void RemoveAll_Should_Clear_Data(string id)
        {
            _sut.RemoveAllItems(new Guid(id));
            _sut.Get(new Guid(id)).Items.Count.ShouldBe(0);
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void AddItem_Should_Add_New_Item(string id)
        {
            _sut.AddItem(new Guid(id), new Item {ItemId = Guid.NewGuid(), ItemCode = "code10", ItemDescription = ""});
            _sut.Get(new Guid(id)).Items.Count.ShouldBe(2);
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void RemoveItem_Should_Remove_New_Items(string id)
        {
            _sut.RemoveItem(new Guid(id),new Guid(id));
            _sut.Get(new Guid(id)).Items.ShouldBeEmpty();
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void IncrementDecrementQuantity_Should_IncreaseQuantity(string id)
        {
            _sut.IncrementDecrementQuantity(new Guid(id),new Guid(id),3);
            _sut.Get(new Guid(id)).Items.First().Quantity.ShouldBe(4);
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void IncrementDecrementQuantity_Should_DecreaseQuantity(string id)
        {
            _sut.IncrementDecrementQuantity(new Guid(id),new Guid(id),-1);
            _sut.Get(new Guid(id)).Items.First().Quantity.ShouldBe(0);
        }
    }
}
