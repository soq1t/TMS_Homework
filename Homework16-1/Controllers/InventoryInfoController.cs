using Homework16_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework16_1.Controllers
{
    [ApiController]
    [Route("product")]
    public class InventoryInfoController : ControllerBase
    {
        private readonly IInventoryService _inventory;

        public InventoryInfoController(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        [HttpGet("amount")]
        public IActionResult GetAmount()
        {
            return Ok(_inventory.GetProductAmount());
        }

        [HttpGet("amount/{category}")]
        public IActionResult GetAmountByCategory(string category)
        {
            return Ok(_inventory.GetProductAmount(category));
        }
    }
}
