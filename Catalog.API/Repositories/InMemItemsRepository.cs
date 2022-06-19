using Catalog.API.DTO;
using Catalog.API.Models;

namespace Catalog.API.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item{ Id = Guid.NewGuid(), Name =  "Potion", Price = 9, Created = DateTimeOffset.UtcNow },
            new Item{ Id = Guid.NewGuid(), Name =  "Sword", Price = 20, Created = DateTimeOffset.UtcNow },
            new Item{ Id = Guid.NewGuid(), Name =  "Bow", Price = 18, Created = DateTimeOffset.UtcNow },
            new Item{ Id = Guid.NewGuid(), Name =  "Armor", Price = 12, Created = DateTimeOffset.UtcNow },
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
            => await Task.FromResult(items);

        public async Task<Item> GetItemAsync(Guid guid)
        {
            var item = items.Where(x => x.Id == guid).SingleOrDefault() ?? new();
            return await Task.FromResult(item);
        }


        public async Task CreateItemAsync(CreateItemDTO item)
        {
            items.Add(item.CreateItemFromDTO());
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(x => x.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid guid)
        {
            var index = items.FindIndex(x => x.Id == guid);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
