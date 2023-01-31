using MediatR;

namespace ehop.Order.API.Queries
{
    public class GetOrdersByUserIdWithMediatr : IRequest<IEnumerable<Models.Order>>
    {
        public int UserId { get; set; }
    }
}

