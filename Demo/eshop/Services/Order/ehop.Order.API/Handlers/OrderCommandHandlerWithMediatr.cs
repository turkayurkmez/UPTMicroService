using ehop.Order.API.Commands;
using MediatR;

namespace ehop.Order.API.Handlers
{
    public class OrderCommandHandlerWithMediatr : IRequestHandler<CreateOrderWithMediatr>
    {
        private ILogger<OrderCommandHandlerWithMediatr> logger;

        public OrderCommandHandlerWithMediatr(ILogger<OrderCommandHandlerWithMediatr> logger)
        {
            this.logger = logger;
        }

        public Task<Unit> Handle(CreateOrderWithMediatr request, CancellationToken cancellationToken)
        {
            //db'ye eklendi....
            logger.LogInformation($"{request.CustomerId} no'lu müşterinin  siparişi eklendi");
            return Task.FromResult(Unit.Value);
        }
    }
}
