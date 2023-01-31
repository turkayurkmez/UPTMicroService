using ehop.Order.API.Queries;
using MediatR;

namespace ehop.Order.API.Handlers
{
    public class OrderQueryHandlerWithMediatr : IRequestHandler<GetOrdersByUserIdWithMediatr, IEnumerable<Models.Order>>
    {
        public async Task<IEnumerable<Models.Order>> Handle(GetOrdersByUserIdWithMediatr request, CancellationToken cancellationToken)
        {
            var orders = new List<Models.Order>();

            orders.Add(new Models.Order
            {
                Id = 1,
                CustomerId = request.UserId,
                OrderDate = DateTime.Now,
                OrderItems = new List<Models.OrderItem>{
                new Models.OrderItem{ UnitPrice=5, Amount=3, ProductId=1}}
            });


            return await Task.FromResult(orders);
        }
    }
}
