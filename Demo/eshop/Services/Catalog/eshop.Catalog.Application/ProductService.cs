using eshop.Catalog.Application.DTOs.Responses;
using eshop.Catalog.DataAccess.Repositories;

namespace eshop.Catalog.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDisplayResponse> GetProducts()
        {

            return _productRepository.GetAllEntities().Select(p => new ProductDisplayResponse
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                UnitPrice = p.UnitPrice
            });

        }
    }
}
