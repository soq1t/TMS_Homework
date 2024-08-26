using Homework17_1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Homework17_1.Services
{
    public enum InventoryServiceCode
    {
        ProductAlreadyExists,
        ProductNotExists,
        SameIdProductExists,
        Ok
    }

    public interface IInventoryService
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product?> GetAsync(int id);

        public Task<InventoryServiceCode> AddAsync(Product product);
        public Task<InventoryServiceCode> ModifyAsync(int id, Product newValues);
        public Task<InventoryServiceCode> DeleteAsync(int id);
    }

    public class InventoryService : IInventoryService
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "\\products.json";

        public async Task<InventoryServiceCode> AddAsync(Product product)
        {
            List<Product> products = await GetProducts();

            if (products.Contains(product))
            {
                return InventoryServiceCode.ProductAlreadyExists;
            }
            //else if (products.Any(p => p.Id == product.Id))
            //{
            //    return InventoryServiceCode.SameIdProductExists;
            //}
            else
            {
                product.Id = (products.Count == 0) ? 1 : products.Last().Id + 1;
                products.Add(product);
                await SaveProducts(products);
                return InventoryServiceCode.Ok;
            }
        }

        public async Task<InventoryServiceCode> DeleteAsync(int id)
        {
            List<Product> products = await GetProducts();

            Product? deleted = products.FirstOrDefault(p => p.Id == id);

            if (deleted == null)
            {
                return InventoryServiceCode.ProductNotExists;
            }
            else
            {
                products.Remove(deleted);
                await SaveProducts(products);
                return InventoryServiceCode.Ok;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await GetProducts();
        }

        public async Task<Product?> GetAsync(int id)
        {
            List<Product> products = await GetProducts();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<InventoryServiceCode> ModifyAsync(int id, Product newValues)
        {
            List<Product> products = await GetProducts();

            Product? product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return InventoryServiceCode.ProductNotExists;
            }
            else
            {
                product.Update(newValues);
                await SaveProducts(products);
                return InventoryServiceCode.Ok;
            }
        }

        private async Task<List<Product>> GetProducts()
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
