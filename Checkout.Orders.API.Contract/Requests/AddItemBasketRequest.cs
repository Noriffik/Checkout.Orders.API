using System.ComponentModel.DataAnnotations;

namespace Checkout.Orders.API.Contract.Requests
{
    public class CreateItemBasketRequest 
    {
        [Required]
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}