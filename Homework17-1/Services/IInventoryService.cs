using Homework17_1.Models;
using Homework17_1.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Homework17_1.Services
{
    public interface IInventoryService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<Product?> GetProductAsync(int id);

        public Task<InventoryRepositoryCode> AddProductAsync(Product product);
        public Task<InventoryRepositoryCode> ModifyProductAsync(int id, Product newValues);
        public Task<InventoryRepositoryCode> DeleteProductAsync(int id);
    }
}
