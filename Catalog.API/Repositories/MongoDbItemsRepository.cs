using Catalog.API.DTO;
using Catalog.API.Models;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private string _database = "catalog";
        private string _collectionName = "items";
        private readonly IMongoCollection<Item> _items;

        public MongoDbItemsRepository(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(_database);
            _items = database.GetCollection<Item>(_collectionName);
        }

        public void CreateItem(CreateItemDTO item)
            => _items.InsertOne(item.CreateItemFromDTO());


        public void DeleteItem(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid guid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UdpateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
