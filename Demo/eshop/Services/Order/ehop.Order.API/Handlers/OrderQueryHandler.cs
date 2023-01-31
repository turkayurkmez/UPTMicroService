using ehop.Order.API.Queries;

namespace ehop.Order.API.Handlers
{
    public class OrderQueryHandler : IQueryHandler<GetOrdersByUserId, IEnumerable<Models.Order>>
    {
        public IEnumerable<Models.Order> Handle(GetOrdersByUserId query)
        {
            throw new NotImplementedException();
        }
    }
}
