namespace ehop.Order.API.Queries
{
    public class GetOrdersByUserId : IQuery
    {
        public int CustomerId { get; set; }
    }
}
