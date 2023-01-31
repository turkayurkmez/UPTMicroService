using eshop.MessageBus;
using MassTransit;

namespace eshop.Basket.API.Consumers
{
    public class ProductPriceChangedConsumer : IConsumer<ProductPriceChangedEvent>
    {
        private readonly ILogger<ProductPriceChangedConsumer> logger;

        public ProductPriceChangedConsumer(ILogger<ProductPriceChangedConsumer> logger)
        {
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<ProductPriceChangedEvent> context)
        {
            var command = context.Message.ProductPriceChangeCommand;
            logger.LogInformation($"{command.ProductId} id'li ürünün yeni fiyatı {command.NewPrice} olarak güncellendi {command.OldPrice - command.NewPrice} TL indirim yapıldı. ");

            return Task.CompletedTask;

        }
    }
}
