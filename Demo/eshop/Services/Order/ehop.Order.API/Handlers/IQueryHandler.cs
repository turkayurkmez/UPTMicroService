using ehop.Order.API.Queries;

namespace ehop.Order.API.Handlers
{
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery
    {
        TResponse Handle(TQuery query);
    }
}
