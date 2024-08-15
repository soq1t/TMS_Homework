using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Homework17_1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }
        public int Amount { get; set; }

        public decimal Price { get; set; }

        public void Update(Product product)
        {
            foreach (
                PropertyInfo prop in typeof(Product).GetProperties().Where(p => p.Name != "Id")
            )
            {
                prop.SetValue(this, prop.GetValue(product));
            }
        }
    }
}
