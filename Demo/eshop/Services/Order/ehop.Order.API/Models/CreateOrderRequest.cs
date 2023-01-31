namespace ehop.Order.API.Models
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
