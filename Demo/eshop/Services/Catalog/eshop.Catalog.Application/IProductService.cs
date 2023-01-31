using eshop.Catalog.Application.DTOs.Responses;

namespace eshop.Catalog.Application
{
    public interface IProductService
    {
        IEnumerable<ProductDisplayResponse> GetProducts();

    }
}
