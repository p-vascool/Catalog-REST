using Catalog.API.Models;

namespace Catalog.API.Repositories
{
    public interface IInMemItemsRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(Guid guid);
    }
}
