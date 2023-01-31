namespace eshop.MessageBus
{
    public class PaymentCompletedEvent
    {
        public int OrderId { get; set; }

    }
    public class PaymentFailedEvent
    {
        public int OrderId { get; set; }
        public string Reason { get; set; }

        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
