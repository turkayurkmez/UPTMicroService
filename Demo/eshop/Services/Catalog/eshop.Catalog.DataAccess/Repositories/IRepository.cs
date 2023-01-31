using eshop.Catalog.Entities;

namespace eshop.Catalog.DataAccess.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IList<T> GetAllEntities();
        T Get(int id);
    }
}
