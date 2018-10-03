using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.API.Contract.Responses;
using Checkout.Orders.Tests.Factory;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Checkout.Orders.Tests
{
    public class BasketItemsControllerTests
        : IClassFixture<ApiApplicationFactory>
    {
        private readonly ApiApplicationFactory _factory;

        public BasketItemsControllerTests(ApiApplicationFactory factory)
        {
            _factory?.Dispose();
            _factory = new ApiApplicationFactory();
        }

        [Theory]
        [InlineData("/api/basket/42b3507c-08e4-4eb7-a5d5-cbef77486fbd/item/42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task Put_Should_Increment_Quantity(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new IncreaseDecreaseItemRequest {Quantity = 3};

            // Act
            var response = await client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            responseContent.ShouldContain("\"quantity\":4");
        }

        [Theory]
        [InlineData("/api/basket/42b3507c-08e4-4eb7-a5d5-cbef77486fbd/item")]
        public async Task Post_Should_Create_New_Item(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var request = new CreateItemBasketRequest {ItemDescription = "test"};
            var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
        }

        [Theory]
        [InlineData("/api/basket/42b3507c-08e4-4eb7-a5d5-cbef77486fbd/item/42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task Put_Should_Decrement_Quantity(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new IncreaseDecreaseItemRequest {Quantity = -1};

            // Act
            var response = await client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            var responseContent = JsonConvert.DeserializeObject<ItemResponseModel>(await response.Content.ReadAsStringAsync());
            responseContent.Quantity.ShouldBe(0);
        }
        [Theory]
        [InlineData("/api/basket/42b3507c-08e4-4eb7-a5d5-cbef77486fbd/item")]
        public async Task Delete_Should_Remove_All_Items(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync(url);
            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }
    }
}