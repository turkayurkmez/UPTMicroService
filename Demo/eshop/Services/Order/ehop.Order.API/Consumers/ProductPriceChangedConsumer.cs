using eshop.MessageBus;
using MassTransit;

namespace ehop.Order.API.Consumers
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
            logger.LogInformation($"{context.Message.ProductPriceChangeCommand.ProductId} ürününde indirim yapıldı. {context.Message.ProductPriceChangeCommand.OldPrice - context.Message.ProductPriceChangeCommand.NewPrice} TL'lik kupon hesabınıza tanımlandı");

            return Task.CompletedTask;
        }
    }
}
