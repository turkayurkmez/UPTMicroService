using eshop.Catalog.Application;
using eshop.MessageBus;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace eshop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProductsController(IProductService productService, IPublishEndpoint publishEndpoint)
        {
            _productService = productService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProducts();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult DiscountProduct(int productId, decimal newPrice)
        {
            //varsayın ki db'de güncelledik...

            var @event = new ProductPriceChangedEvent();
            var command = new ProductPriceChangeCommand
            {
                NewPrice = newPrice,
                OldPrice = 100,
                ProductId = 3
            };
            @event.ProductPriceChangeCommand = command;
            _publishEndpoint.Publish(@event);

            return Ok();

        }
    }
}
