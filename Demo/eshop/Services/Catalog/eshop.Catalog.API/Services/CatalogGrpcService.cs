using eshop.Catalog.API.Proto;
using eshop.Catalog.Application;
using Grpc.Core;

namespace eshop.Catalog.API.Services
{
    public class CatalogGrpcService : CatalogService.CatalogServiceBase
    {
        private readonly IProductService productService;

        public CatalogGrpcService(IProductService productService)
        {
            this.productService = productService;
        }

        public override Task<ProductMessage> GetProducts(EmptyParameter request, ServerCallContext context)
        {

            var product = productService.GetProducts().FirstOrDefault();
            var message = new ProductMessage { Name = product.Name, Price = 5 };
            return Task.FromResult(message);
        }
    }
}
