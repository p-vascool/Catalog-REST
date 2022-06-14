using Catalog.API.DTO;
using Catalog.API.Models;

namespace Catalog.API.Repositories
{
    public class InMemItemsRepository : IInMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item{ Id = Guid.NewGuid(), Name =  "Potion", Price = 9, Created = DateTimeOffset.UtcNow },
            new Item{ Id = Guid.NewGuid(), Name =  "Sword", Price = 20, Created = DateTimeOffset.UtcNow },
            new Item{ Id = Guid.NewGuid(), Name =  "Bow", Price = 18, Created = DateTimeOffset.UtcNow },
            new Item{ Id = Guid.NewGuid(), Name =  "Armor", Price = 12, Created = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
            => items;

        public Item GetItem(Guid guid)
            => items.Where(x => x.Id == guid).SingleOrDefault() ?? new();

        public void CreateItem(CreateItemDTO item)
            => items.Add(item.CreateItemFromDTO());

        public void UdpateItem(Item item)
        {
            var index = items.FindIndex(x => x.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid guid)
        {
            var index = items.FindIndex(x => x.Id == guid);
            items.RemoveAt(index);
        }
    }
}
