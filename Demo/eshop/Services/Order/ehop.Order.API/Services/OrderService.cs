namespace ehop.Order.API.Services
{
    public class OrderService
    {
        public Models.Order GetOrder(int id)
        {
            return new Models.Order { Id = id, OrderState = Models.OrderState.Pending };
        }
    }
}
