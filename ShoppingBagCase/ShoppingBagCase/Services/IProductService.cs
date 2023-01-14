using ShoppingBagCase.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBagCase.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAsync();

        Task<Product?> GetAsync(string id);

        Task CreateAsync(Product newBook);

        Task UpdateAsync(string id, Product updatedBook);

        Task RemoveAsync(string id);
    }
}
