using eshop.MessageBus;
using MassTransit;

namespace eshop.Stock.API.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreatedEvent>
    {
        IPublishEndpoint _publishEndPoint;

        public OrderCreatedConsumer(IPublishEndpoint publishEndPoint)
        {
            _publishEndPoint = publishEndPoint;
        }

        public Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            if (stockAvailable(context.Message.OrderItems))
            {

                //eğer stokta varsa; satın alınan ürünlerin adetleri stoktan düşülecek

                var @event = new StockReservedEvent
                {
                    CreditCartInfo = context.Message.CreditCardInfo,
                    CustomerId = context.Message.CustomerId,
                    OrderId = context.Message.OrderId,
                    OrderItems = context.Message.OrderItems
                };
                _publishEndPoint.Publish(@event);
            }
            else
            {
                var @event = new StockNotReservedEvent
                {
                    OrderId = context.Message.OrderId,
                    CustomerId = context.Message.CustomerId,

                };

                _publishEndPoint.Publish(@event);
            }

            return Task.CompletedTask;
        }

        private bool stockAvailable(List<OrderItemMessage> orderItems)
        {
            return new Random().Next(0, 10) % 2 == 0;
        }
    }
}
