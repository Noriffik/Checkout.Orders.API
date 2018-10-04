using System.ComponentModel.DataAnnotations;

namespace Checkout.Orders.API.Contract.Requests
{
    public class IncreaseDecreaseItemRequest
    {
        [Required]
        public int Quantity { get; set; }
    }
}
