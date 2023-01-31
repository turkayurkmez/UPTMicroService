using eshop.Catalog.Entities;

namespace eshop.Catalog.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IList<Product> GetProductsByName(string productName);

    }
}
