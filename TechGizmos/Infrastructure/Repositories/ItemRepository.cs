using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechGizmos.TechGizmos.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IMongoCollection<Item> _items;

        public ItemRepository(MongoDBContext context)
        {
            _items = context.GetCollection<Item>("Items");
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _items.Find(_ => true).ToListAsync();
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            return await _items.Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Item item)
        {
            item.Id = ObjectId.GenerateNewId().ToString(); // Genera un nuevo ObjectId como string.
            await _items.InsertOneAsync(item);
        }

        public async Task UpdateAsync(Item item)
        {
            await _items.ReplaceOneAsync(i => i.Id == item.Id, item);
        }

        public async Task DeleteAsync(string id)
        {
            await _items.DeleteOneAsync(item => item.Id == id);
        }

        public Task<Item> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
