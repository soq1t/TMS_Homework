namespace Homework16_1
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public void Update(Product product)
        {
            Name = product.Name;
            Category = product.Category;
            Amount = product.Amount;
            Price = product.Price;
        }
    }
}
