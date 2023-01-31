using eshop.MessageBus;
using MassTransit;

namespace ehop.Order.API.Consumers
{
    public class StockConsumer : IConsumer<StockNotReservedEvent> //IConsumer<StockReservedEvent>
    {
        private readonly ILogger<StockConsumer> _logger;

        public StockConsumer(ILogger<StockConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<StockNotReservedEvent> context)
        {
            var order = new Models.Order();
            order.OrderState = Models.OrderState.Failed;
            _logger.LogInformation($"{context.Message.OrderId}'li sipariş tamamlanamadı. {order.OrderState} ");
            return Task.CompletedTask;
        }

        //public Task Consume(ConsumeContext<StockReservedEvent> context)
        //{
        //    var order = new Models.Order();
        //    order.OrderState = Models.OrderState.Compeleted;
        //    _logger.LogInformation($"{context.Message.OrderId}'li sipariş tamamlandı. {order.OrderState} ");
        //    return Task.CompletedTask;
        //}
    }
}
