using Homework17_1.Models;
using Homework17_1.Repositories;
using Homework17_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework17_1.API
{
    [ApiController]
    [Route("api/products")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Json(await _inventoryService.GetProductsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            Product? product = await _inventoryService.GetProductAsync(id);

            if (product == null)
            {
                return BadRequest($"Нет товара с Id = {id}");
            }
            else
            {
                return Json(product);
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(Product product)
        {
            InventoryRepositoryCode code = await _inventoryService.AddProductAsync(product);

            if (code == InventoryRepositoryCode.ProductAlreadyExists)
            {
                return BadRequest($"Такой товар уже есть на складе");
            }
            else if (code == InventoryRepositoryCode.SameIdProductExists)
            {
                return BadRequest($"Товар с id = {product.Id} уже есть на складе");
            }
            else
            {
                return Ok("Товар был добавлен на склад!");
            }
        }

        [HttpPost]
        [Route("{id}/modify")]
        public async Task<IActionResult> ModifyAsync([FromRoute] int id, Product newValues)
        {
            InventoryRepositoryCode code = await _inventoryService.ModifyProductAsync(
                id,
                newValues
            );

            if (code == InventoryRepositoryCode.ProductNotExists)
            {
                return BadRequest($"Товара с id = {id} нет на складе");
            }
            else
            {
                return Ok($"Товар с if = {id} был успешно отредактирован");
            }
        }

        [HttpPost]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            InventoryRepositoryCode code = await _inventoryService.DeleteProductAsync(id);

            if (code == InventoryRepositoryCode.ProductNotExists)
            {
                return BadRequest($"Нет товара с id = {id}");
            }
            else
            {
                return Ok("Товар успешно удалён!");
            }
        }
    }
}
