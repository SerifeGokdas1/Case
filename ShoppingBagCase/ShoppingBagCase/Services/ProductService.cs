using ShoppingBagCase.Data;
using ShoppingBagCase.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBagCase.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductData _productData;

        public ProductService(IProductData productData)
        {
            _productData = productData;
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _productData.GetAsync();
        }

        public async Task<Product?> GetAsync(string id)
        {
            return await _productData.GetAsync(id);
        }

        public async Task CreateAsync(Product newBook)
        {
            await _productData.CreateAsync(newBook);
        }

        public async Task UpdateAsync(string id, Product updatedBook)
        {
            await _productData.UpdateAsync(id, updatedBook);
        }

        public async Task RemoveAsync(string id)
        {
            await _productData.RemoveAsync(id);
        }
    }
}
