using FinalApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalApi.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public StudentServices(IOptions<DatabaseSetting> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Connection);
            var mongoDb = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _studentCollection = mongoDb.GetCollection<Student>(settings.Value.CollectionName);
        }

        public async Task<List<Product>> GetAllAsync() =>
            await _products.Find(p => true).ToListAsync();

        public async Task<Product?> GetByIdAsync(string id) =>
            await _products.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Product product) =>
            await _products.InsertOneAsync(product);

        public async Task UpdateAsync(string id, Product product) =>
            await _products.ReplaceOneAsync(p => p.Id == id, product);

        public async Task DeleteAsync(string id) =>
            await _products.DeleteOneAsync(p => p.Id == id);
    }
}
