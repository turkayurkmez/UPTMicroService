using ehop.Order.API.Models;

namespace ehop.Order.API.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
