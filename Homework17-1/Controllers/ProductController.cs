using Homework17_1.Models;
using Homework17_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework17_1.Controllers
{
    [Controller]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public ProductController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Index()
        {
            return View("Add", null);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromForm] Product product)
        {
            await _inventoryService.AddAsync(product);
            List<Product> products = await _inventoryService.GetAllAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> Remove(Product product)
        {
            await _inventoryService.DeleteAsync(product.Id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("{id}/modify")]
        public async Task<IActionResult> Modify([FromRoute] int id)
        {
            Product? product = await _inventoryService.GetAsync(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Add", product);
            }
        }

        [HttpPost]
        [Route("modify")]
        public async Task<IActionResult> Modify([FromForm] Product product)
        {
            await _inventoryService.ModifyAsync(product.Id, product);

            return RedirectToAction("Index", "Home");
        }
    }
}
