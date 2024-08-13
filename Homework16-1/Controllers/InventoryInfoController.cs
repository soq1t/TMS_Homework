using Homework16_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework16_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryInfoController : ControllerBase
    {
        private readonly IInventoryService _inventory;

        public InventoryInfoController(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        [HttpGet("GetAmount")]
        public int GetAmount()
        {
            return _inventory.GetProductAmount();
        }

        [HttpGet("GetAmountByCategory")]
        public int GetAmountByCategory(string category)
        {
            return _inventory.GetProductAmount(category);
        }
    }
}
