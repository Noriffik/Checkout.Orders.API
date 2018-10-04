using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Checkout.Orders.API.Contract.Requests;
using Checkout.Orders.Tests.Factory;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Checkout.Orders.Tests
{
    public class BasketControllerTests
        : IClassFixture<ApiApplicationFactory>
    {
        private readonly ApiApplicationFactory _factory;
        private readonly JsonSerializerSettings _serializerSettings;
       
        public BasketControllerTests()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };


            _factory?.Dispose();
            _factory = new ApiApplicationFactory();
           
        }

        [Theory]
        [InlineData("/api/basket")]
        public async Task GetAll_Should_Return_RightData(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode(); 
            responseContent.ShouldBe(JsonConvert.SerializeObject(new Constants().BASKET(), _serializerSettings));

        }

        [Theory]
        [InlineData("/api/basket/42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task Get_Should_Return_RightData(string url)
        {
         
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            responseContent.ShouldBe(JsonConvert.SerializeObject(new Constants().BASKET().FirstOrDefault(), _serializerSettings));
        }

        [Theory]
        [InlineData("/api/basket", "test-email@test-com")]
        public async Task Post_EndpointsReturnSuccess(string url, string email)
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new StringContent(JsonConvert.SerializeObject(new CreateBasketRequest
                {Email = email}), Encoding.UTF8, "application/json");

            request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Act
            var response = await client.PostAsync(url, request);
            var responseContent = await response.Content.ReadAsStringAsync();
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.StatusCode.ShouldBe(HttpStatusCode.Created);
        }

        [Theory]
        [InlineData("/api/basket/00000000-0000-0000-0000-000000000000", "test-email-updated@test-com")]
        public async Task Put_OnNotExistingResource(string url, string email)
        {
            // Arrange
            var client = _factory.CreateClient();
            var request = new StringContent(JsonConvert.SerializeObject(new UpdateBasketRequest
                {Email = email}), Encoding.UTF8, "application/json");

            request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Act
            var response = await client.PutAsync(url, request);
            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);

        }

        [Theory]
        [InlineData("/api/basket/00000000-0000-0000-0000-000000000000")]
        public async Task Delete_OnNotExistingResource(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync(url);
            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("/api/basket/00000000-0000-0000-0000-000000000000")]
        public async Task Get_OnNotExistingResource(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync(url);
            // Assert
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Theory]
        [InlineData("/api/basket/42b3507c-08e4-4eb7-a5d5-cbef77486fbd")]
        public async Task Delete_EndpointsReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.DeleteAsync(url);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        }
    }
}