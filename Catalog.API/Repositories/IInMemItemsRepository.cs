using Catalog.API.DTO;
using Catalog.API.Models;

namespace Catalog.API.Repositories
{
    public interface IInMemItemsRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(Guid guid);
        void CreateItem(CreateItemDTO item);
        void UdpateItem(Item item);
        void DeleteItem(Guid guid);
    }
}
