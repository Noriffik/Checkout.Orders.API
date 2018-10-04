using System;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Orders.API.Client.Tests.Factory;
using Checkout.Orders.API.Contract.Requests;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Checkout.Orders.API.Client.Tests
{
    public class ItemClientTests
        : IClassFixture<ApiApplicationFactory>
    {
        private readonly ApiApplicationFactory _factory;
        private readonly JsonSerializerSettings _serializerSettings;

        public ItemClientTests()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };

            _factory?.Dispose();
            _factory = new ApiApplicationFactory();
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task GetItems_Should_Return_Right_Data(string id)
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            var response = await client.Item.GetItems(new Guid(id));
            // Assert
            response.Count().ShouldBe(1);
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task ItemIncrementDecrement_Should_Add_Quantity(string id)
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            var response = await client.Item.IncreaseDecreaseItem(new Guid(id), new Guid(id), 5 );
            // Assert
            response.Quantity.ShouldBe(6);
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task ItemIncrementDecrement_Should_Remove_Quantity(string id)
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            var response = await client.Item.IncreaseDecreaseItem(new Guid(id), new Guid(id), -1 );
            // Assert
            response.Quantity.ShouldBe(0);
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task AddItem_Should_Add_New_Item(string id)
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            var response = await client.Item.AddItem(new Guid(id), new CreateItemBasketRequest
            {
                ItemDescription = "test",
                ItemCode =  "code10",
                Quantity = 34
            });

            response.ShouldNotBeEmpty();
        }
    }
}