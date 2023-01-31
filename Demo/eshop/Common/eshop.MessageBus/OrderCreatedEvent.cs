namespace eshop.MessageBus
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }
        public string CreditCardInfo { get; set; }
    }

    public class OrderItemMessage
    {
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int Amount { get; set; }
    }


}
