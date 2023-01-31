using eshop.MessageBus;
using MassTransit;

namespace eshop.Payment.API.Consumers
{
    public class StockReservedConsumer : IConsumer<StockReservedEvent>
    {
        private readonly ILogger<StockReservedConsumer> _logger;
        private readonly IPublishEndpoint _publishEndpoint;


        public StockReservedConsumer(ILogger<StockReservedConsumer> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(ConsumeContext<StockReservedEvent> context)
        {

            if (checkPayment(context.Message.CreditCartInfo, context.Message.OrderItems))
            {
                var paymentCompletedEvent = new PaymentCompletedEvent { OrderId = context.Message.OrderId };
                _publishEndpoint.Publish(paymentCompletedEvent);
            }
            else
            {
                var @event = new PaymentFailedEvent
                {
                    OrderId = 1,
                    Reason = "CCV Bilgisi hatalı",
                    OrderItems = context.Message.OrderItems
                };
                _publishEndpoint.Publish(@event);
            }

            return Task.CompletedTask;
        }

        private bool checkPayment(string creditCartInfo, List<OrderItemMessage> orderItems)
        {
            return false;
            //return new Random().Next(1, 10) % 2 == 0;
        }
    }
}
