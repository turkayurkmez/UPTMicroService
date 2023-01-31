using eshop.Catalog.Entities;

namespace eshop.Catalog.DataAccess.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        private List<Product> products;
        public FakeProductRepository()
        {
            products = new List<Product>
            {
                new Product{ Id=1, Name="xyz", UnitPrice=100},
                new Product{ Id=2, Name="abc", UnitPrice=100},
                new Product{ Id=3, Name="def", UnitPrice=100},

            };
        }
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllEntities()
        {
            return products;
        }

        public IList<Product> GetProductsByName(string productName)
        {
            throw new NotImplementedException();
        }
    }
}
