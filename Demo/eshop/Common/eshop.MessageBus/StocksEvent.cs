namespace eshop.MessageBus
{
    public class StockReservedEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }
        public string CreditCartInfo { get; set; }
    }

    public class StockNotReservedEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
    }
}
