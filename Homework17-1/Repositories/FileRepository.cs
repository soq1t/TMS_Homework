using Homework17_1.Models;
using Newtonsoft.Json;

namespace Homework17_1.Repositories
{
    public class FileRepository : IInvetoryRepository
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "\\products.json";

        public async Task<InventoryRepositoryCode> AddProductAsync(Product product)
        {
            List<Product> products = await GetProductsAsync();

            if (products.Contains(product) || products.Any(p => p.Id == product.Id))
            {
                return InventoryRepositoryCode.ProductAlreadyExists;
            }
            else
            {
                product.Id = (products.Count == 0) ? 1 : products.Last().Id + 1;
                products.Add(product);
                await SaveProducts(products);
                return InventoryRepositoryCode.Ok;
            }
        }

        public async Task<InventoryRepositoryCode> DeleteProductAsync(int id)
        {
            List<Product> products = await GetProductsAsync();

            Product? deleted = products.FirstOrDefault(p => p.Id == id);

            if (deleted == null)
            {
                return InventoryRepositoryCode.ProductNotExists;
            }
            else
            {
                products.Remove(deleted);
                await SaveProducts(products);
                return InventoryRepositoryCode.Ok;
            }
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            FileStream file = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader reader = new StreamReader(file))
            {
                string? jsonData = await reader.ReadToEndAsync();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    return JsonConvert.DeserializeObject<List<Product>>(jsonData);
                }
                else
                {
                    return new List<Product>();
                }
            }
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            List<Product> products = await GetProductsAsync();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<InventoryRepositoryCode> ModifyProductAsync(int id, Product newValues)
        {
            List<Product> products = await GetProductsAsync();

            Product? product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return InventoryRepositoryCode.ProductNotExists;
            }
            else
            {
                product.Update(newValues);
                await SaveProducts(products);
                return InventoryRepositoryCode.Ok;
            }
        }

        private async Task SaveProducts(List<Product> products)
        {
            FileStream file = new FileStream(_filePath, FileMode.Create, FileAccess.Write);

            using (StreamWriter writer = new StreamWriter(file))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(products, Formatting.Indented));
            }
        }
    }
}
