namespace Homework16_1
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public void Update(
            string? productName = null,
            string? category = null,
            int? amount = null,
            decimal? price = null
        )
        {
            Name = productName ?? Name;
            Category = category ?? Category;
            Amount = amount ?? Amount;
            Price = price ?? Price;
        }
    }
}
