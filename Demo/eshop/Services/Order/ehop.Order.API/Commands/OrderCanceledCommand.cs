namespace ehop.Order.API.Commands
{
    public class OrderCanceledCommand : ICommand
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

    }
}
