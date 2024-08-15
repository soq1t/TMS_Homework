using Homework17_1.Models;
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
            return Json(await _inventoryService.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            Product? product = await _inventoryService.GetAsync(id);

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
            InventoryServiceCode code = await _inventoryService.AddAsync(product);

            if (code == InventoryServiceCode.ProductAlreadyExists)
            {
                return BadRequest($"Такой товар уже есть на складе");
            }
            else if (code == InventoryServiceCode.SameIdProductExists)
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
            InventoryServiceCode code = await _inventoryService.ModifyAsync(id, newValues);

            if (code == InventoryServiceCode.ProductNotExists)
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
            InventoryServiceCode code = await _inventoryService.DeleteAsync(id);

            var request = HttpContext.Request;

            if (code == InventoryServiceCode.ProductNotExists)
            {
                return BadRequest($"Нет товара с id = {id}");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
