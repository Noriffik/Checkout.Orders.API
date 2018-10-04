using System;
using System.Threading.Tasks;
using Checkout.Orders.API.Client.Tests.Factory;
using Checkout.Orders.API.Contract.Requests;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Checkout.Orders.API.Client.Tests
{
    public class BasketClientTests
        : IClassFixture<ApiApplicationFactory>
    {
        private readonly ApiApplicationFactory _factory;
        private readonly JsonSerializerSettings _serializerSettings;

        public BasketClientTests()
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
        public async Task Basket_Get_Should_Return_Right_Data(string id)
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            var response = await client.Basket.Get(new Guid(id));
            // Assert
            response.BasketId.ShouldBe(new Guid(id));
        }

        [Fact]
        public async Task Basket_Create_Should_Return_Right_Data()
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            var response = await client.Basket.Create( new CreateBasketRequest
            {
                Email = "samuele.resca@gmail.com"
            });

            response.ShouldNotBeEmpty();
           
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void Basket_Delete_Should_Return_Right_Data(string id)
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            Should.NotThrow(async () => { await client.Basket.Delete(new Guid(id)); });
        }

        [Theory]
        [InlineData("42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public void RemoveAll_Should_Return_Empty(string id)
        {
            // Arrange
            var client = new OrderApiClient(_factory.CreateClient());
            // Act
            Should.NotThrow(async () => { await client.Basket.RemoveAll(new Guid(id)); });
        }

    }
}