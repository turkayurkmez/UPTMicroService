using eshop.MessageBus;
using MassTransit;
using System.Text;

namespace eshop.Stock.API.Consumers
{
    public class PaymentFailedConsumer : IConsumer<PaymentFailedEvent>
    {
        private ILogger<PaymentFailedConsumer> _logger;

        public PaymentFailedConsumer(ILogger<PaymentFailedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentFailedEvent> context)
        {
            StringBuilder logResult = new StringBuilder();
            context.Message.OrderItems.ForEach(oi => logResult.Append($"{oi.ProductId} id'li ürünün stoğu {oi.Amount} kadar arttırıldı"));

            _logger.LogInformation($"Durum: {logResult}");

            return Task.CompletedTask;
        }
    }
}
