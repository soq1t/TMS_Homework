using Homework16_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework16_1.Controllers
{
    [ApiController]
    [Route("product")]
    public class InventoryEditController : ControllerBase
    {
        private readonly IInventoryService _inventory;

        public InventoryEditController(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(_inventory.Products);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            bool result = _inventory.AddProduct(product);
            if (result)
            {
                return Ok($"Продукт [{product.Name}] успешно добавлен!");
            }
            else
            {
                return BadRequest(
                    $"Не удалось добавить продукт [{product.Name}] (он уже есть на складе)!"
                );
            }
        }

        [HttpPatch("edit/{productId}")]
        public IActionResult Edit(
            int productId,
            string? productName = null,
            string? category = null,
            int? amount = null,
            decimal? price = null
        )
        {
            bool result = _inventory.EditProduct(productId, productName, category, amount, price);

            return result
                ? Ok($"Продукт с id={productId} успешно изменён!")
                : BadRequest($"Продукта с id={productId} нет на складе!");
        }
    }
}
