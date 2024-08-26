using Homework17_1.Models;

namespace Homework17_1.Repositories
{
    public enum InventoryRepositoryCode
    {
        ProductAlreadyExists,
        ProductNotExists,
        SameIdProductExists,
        Ok
    }

    public interface IInvetoryRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductAsync(int id);
        Task<InventoryRepositoryCode> AddProductAsync(Product product);
        Task<InventoryRepositoryCode> ModifyProductAsync(int id, Product newValues);
        Task<InventoryRepositoryCode> DeleteProductAsync(int id);
    }
}
