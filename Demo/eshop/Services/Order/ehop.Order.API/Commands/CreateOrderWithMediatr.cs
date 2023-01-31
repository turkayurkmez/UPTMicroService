using ehop.Order.API.Models;
using MediatR;

namespace ehop.Order.API.Commands
{
    public class CreateOrderWithMediatr : IRequest
    {
        public int CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
