using System.ComponentModel.DataAnnotations;

namespace Checkout.Orders.API.Contract.Requests
{
    public class CreateBasketRequest
    {
        [Required]
        public string Email { get; set; }
    }
}