namespace ehop.Order.API.Models
{

    public enum OrderState
    {
        Pending,
        Completed,
        Failed,
        Canceled
    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public decimal? TotalPrice { get => OrderItems.Sum(x => x.Amount * x.UnitPrice); }
        public OrderState OrderState { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Amount { get; set; }

    }
}
