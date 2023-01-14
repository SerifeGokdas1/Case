using ShoppingBagCase.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBagCase.Data
{
    public interface IProductData
    {
        Task<List<Product>> GetAsync();
        Task<Product?> GetAsync(string id);
        Task CreateAsync(Product newBook);
        Task UpdateAsync(string id, Product updatedBook);
        Task RemoveAsync(string id);
    }
}
