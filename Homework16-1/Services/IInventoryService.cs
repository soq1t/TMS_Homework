namespace Homework16_1.Services
{
    public interface IInventoryService
    {
        public List<Product> Products { get; }

        public bool AddProduct(Product product);

        public bool RemoveProduct(Product product);

        public bool EditProduct(
            int id,
            string? productName = null,
            string? category = null,
            int? amount = null,
            decimal? price = null
        );

        public int GetProductAmount();

        public int GetProductAmount(string category);
    }

    public class InventoryService : IInventoryService
    {
        public List<Product> Products { get; private set; }

        public InventoryService()
        {
            Products = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            if (!Products.Contains(product))
            {
                Products.Add(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetProductAmount()
        {
            int amount = 0;

            foreach (Product product in Products)
            {
                amount += product.Amount;
            }

            return amount;
        }

        public int GetProductAmount(string category)
        {
            int amount = 0;

            foreach (Product product in Products.Where(p => p.Category == category))
            {
                amount += product.Amount;
            }

            return amount;
        }

        public bool RemoveProduct(Product product)
        {
            if (Products.Contains(product))
            {
                Products.Remove(product);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditProduct(
            int id,
            string? productName = null,
            string? category = null,
            int? amount = null,
            decimal? price = null
        )
        {
            Product? editedProduct = Products.FirstOrDefault(p => p.Id == id);
            if (editedProduct != null)
            {
                editedProduct.Update(productName, category, amount, price);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
