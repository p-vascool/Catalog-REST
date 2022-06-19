using Catalog.API.DTO;
using Catalog.API.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class MongoDbItemsRepository : IItemsRepository
    {
        private string _database = "catalog";
        private string _collectionName = "items";
        private readonly IMongoCollection<Item> _items;
        private readonly FilterDefinitionBuilder<Item> _filter = Builders<Item>.Filter;

        public MongoDbItemsRepository(IMongoClient client)
        {
            IMongoDatabase database = client.GetDatabase(_database);
            _items = database.GetCollection<Item>(_collectionName);
        }

        public async Task CreateItemAsync(CreateItemDTO item)
            => await _items.InsertOneAsync(item.CreateItemFromDTO());


        public async Task DeleteItemAsync(Guid guid)
        {
            var filter = _filter.Eq(item => item.Id, guid);
            await _items.DeleteOneAsync(filter);
        }

        public async Task<Item> GetItemAsync(Guid guid)
        {
            var filter = _filter.Eq(item => item.Id, guid);
            return await _items.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
            => await _items.Find(new BsonDocument()).ToListAsync();

        public async Task UpdateItemAsync(Item item)
        {
            var filter = _filter.Eq(item => item.Id, item.Id);
            await _items.ReplaceOneAsync(filter, item);
        }
    }
}
