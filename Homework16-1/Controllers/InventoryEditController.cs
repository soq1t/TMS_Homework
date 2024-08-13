using Homework16_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework16_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryEditController : ControllerBase
    {
        private readonly IInventoryService _inventory;

        public InventoryEditController(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        [HttpGet("GetProducts")]
        public List<Product> Get()
        {
            return _inventory.Products;
        }

        [HttpPost("AddProduct")]
        public string Add(Product product)
        {
            bool result = _inventory.AddProduct(product);
            if (result)
            {
                return "Продукт был успешно добавлен!";
            }
            else
            {
                return "Не удалось добавить продукт";
            }
        }

        [HttpPatch("EditProduct")]
        public string Edit(int productId, Product product)
        {
            bool result = _inventory.EditProduct(productId, product);

            return result ? "Продукт успешно изменён!" : "Такого продукта нет на складе!";
        }
    }
}
