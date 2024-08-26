using Homework17_1.Models;
using Homework17_1.Repositories;

namespace Homework17_1.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInvetoryRepository _invetoryRepository;

        public InventoryService(IInvetoryRepository invetoryRepository)
        {
            _invetoryRepository = invetoryRepository;
        }

        public async Task<InventoryRepositoryCode> AddProductAsync(Product product)
        {
            return await _invetoryRepository.AddProductAsync(product);
        }

        public async Task<InventoryRepositoryCode> DeleteProductAsync(int id)
        {
            return await _invetoryRepository.DeleteProductAsync(id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _invetoryRepository.GetProductsAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _invetoryRepository.GetProductAsync(id);
        }

        public async Task<InventoryRepositoryCode> ModifyProductAsync(int id, Product newValues)
        {
            return await _invetoryRepository.ModifyProductAsync(id, newValues);
        }
    }
}
