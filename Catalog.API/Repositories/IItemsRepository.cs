using Catalog.API.DTO;
using Catalog.API.Models;

namespace Catalog.API.Repositories
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid guid);
        Task CreateItemAsync(CreateItemDTO item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid guid);
    }
}
