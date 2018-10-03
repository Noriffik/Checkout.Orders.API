namespace Checkout.Orders.API.Contract.Requests
{
    public class CreateItemBasketRequest 
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
    }
}