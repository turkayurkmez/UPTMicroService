namespace ehop.Order.API.Commands
{
    public class UpdateOrderStatusToFailedCommand : ICommand
    {
        public int OrderId { get; set; }
    }
}
