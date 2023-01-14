using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ShoppingBagCase.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoppingBagCase.Models;

namespace ShoppingBagCase.Data
{
    public class MongoDBProductData:IProductData
    {
        private readonly IMongoCollection<Product> _productsCollection;

        public MongoDBProductData(IOptions<ProductDBSetting> productDBSetting)
        {   var mongoClient = new MongoClient(productDBSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDBSetting.Value.DatabaseName);
            _productsCollection = mongoDatabase.GetCollection<Product>(productDBSetting.Value.ProductsCollectionName);
        }

        public async Task CreateAsync(Product newBook)
        {
            await _productsCollection.InsertOneAsync(newBook);
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _productsCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetAsync(string id)
        {
            return await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            await _productsCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, Product updatedBook)
        {
            await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
        }
    }
}
