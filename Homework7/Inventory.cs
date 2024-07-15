using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHomeworkToolkit;

namespace Homework7
{
    internal class Inventory
    {
        private static readonly CultureInfo culture = new CultureInfo("en-US");
        public List<Product> Products { get; private set; }

        public Inventory()
        {
            Products = new List<Product>();
        }

        public void PrintProducts()
        {
            if (Products.Count == 0)
            {
                ConsoleUtility.WriteLineColored("На складе отсутствуют товары!", ConsoleColor.Cyan);
            }
            else
            {
                ConsoleUtility.WriteLineColored(
                    "Продукты, содержащиеся на складе:",
                    ConsoleColor.Yellow
                );
                foreach (Product product in Products)
                {
                    product.PrintInfo();
                }
                Console.WriteLine();
                PrintSummaryPrice();
            }
        }

        public double GetSummaryPrice()
        {
            if (Products.Count == 0)
                return 0;

            double sum = 0;
            foreach (Product product in Products)
                sum += product.Price * product.Amount;

            return sum;
        }

        public void PrintSummaryPrice()
        {
            ConsoleUtility.WriteColored("Общая стоимость товаров на складе: ", ConsoleColor.Cyan);
            ConsoleUtility.WriteLineColored(
                string.Format(culture, "{0:C2}", GetSummaryPrice()),
                ConsoleColor.Green
            );
        }

        public void AddProduct(Product product)
        {
            if (Products.Any(p => p.Id == product.Id))
            {
                ConsoleUtility.WriteLineColored(
                    "Такой товар уже есть на складе!",
                    ConsoleColor.Red
                );
                Console.ReadKey(true);
            }
            else
            {
                Products.Add(product);
            }
        }

        public Product GetProduct(int id)
        {
            Product product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                ConsoleUtility.WriteLineColored($"Отсутствует товар с Id = {id}", ConsoleColor.Red);
                Console.ReadKey(true);
            }

            return product;
        }
    }
}
