using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBagCase.Models.ShoppingBag;
using ShoppingBagCase.Services;
using System.Collections.Generic;

namespace ShoppingBagCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingBagController : ControllerBase
    {
        private readonly IShoppingBagService _shoppingbagService;

        public ShoppingBagController(IShoppingBagService shoppingbagService)
        {
            _shoppingbagService = shoppingbagService;
        }

        [HttpGet]
        public ActionResult<List<ShoppingBagTransfer>> GetAll()
        {
            var list = _shoppingbagService.GetAll();
            if (list != null)
            {
                return list;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddToShoppingBag(CreateShoppingBag shoppingbagTransfer)
        {
_shoppingbagService.AddToShoppingBag(shoppingbagTransfer.ProductId, shoppingbagTransfer.Price);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateQuantity(UpdateShoppingBag updateShoppingbag)
        {
            _shoppingbagService.UpdatePrice(updateShoppingbag.ShoppingBagId, updateShoppingbag.Price); 

            return Ok();
        }

        [HttpDelete("{cartId}")]
        public ActionResult<List<ShoppingBagTransfer>> DeleteShoppingBag(string ShoppingBagId)
        {
            _shoppingbagService.DeleteShoppingBag(ShoppingBagId);

            return Ok();
        }
    }
}
