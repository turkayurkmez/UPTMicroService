using ehop.Order.API.Services;
using eshop.MessageBus;
using MassTransit;

namespace ehop.Order.API.Consumers
{
    public class PaymentEventsConsumer : IConsumer<PaymentCompletedEvent>,
                                         IConsumer<PaymentFailedEvent>
    {
        private OrderService orderService;
        private readonly ILogger<PaymentEventsConsumer> logger;
        public PaymentEventsConsumer(ILogger<PaymentEventsConsumer> logger)
        {
            orderService = new OrderService();
            this.logger = logger;
        }
        public Task Consume(ConsumeContext<PaymentCompletedEvent> context)
        {
            var order = orderService.GetOrder(context.Message.OrderId);
            order.OrderState = Models.OrderState.Completed;
            logger.LogInformation("Sipariş tamamlandı");
            //varsayın ki db'ye kaydedildi
            return Task.CompletedTask;

        }

        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            var order = orderService.GetOrder(context.Message.OrderId);
            order.OrderState = Models.OrderState.Failed;
            logger.LogInformation($"Sipariş tamamlanamadı. Nedeni: {context.Message.Reason} ");
            //varsayın ki db'ye kaydedildi
            return Task.CompletedTask;
        }
    }
}
