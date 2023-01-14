using ShoppingBagCase.Data;
using ShoppingBagCase.Models.ShoppingBag;
using System.Collections.Generic;

namespace ShoppingBagCase.Services
{
    public class ShoppingBagService:IShoppingBagService
    {
        private readonly IShoppingData _shoppingData;
        private IProductData _productData;

        public ShoppingBagService(IShoppingData shoppingData, IProductData productData)
        {
            _shoppingData = shoppingData;
            _productData = productData;
        }

        public void AddToShoppingBag(string productId, int price)
        {
            _shoppingData.AddToShoppingBag(productId, price);
        }



        public void DeleteShoppingBag(string shoppingbagId)
        {
            _shoppingData.DeleteShoppingBag(shoppingbagId);
        }


        public List<ShoppingBagTransfer> GetAll()
        {
            var retVal = new List<ShoppingBagTransfer>();

            var shoppingbags = _shoppingData.GetAll();
            foreach (var shoppingbag in shoppingbags)
            {
                var transfer = new ShoppingBagTransfer()
                {
                    Id = shoppingbag.Id,
                    ProductId = shoppingbag.ProductId,
                    Price = shoppingbag.Price
                };

                transfer.ProductName = _productData.GetAsync(shoppingbag.ProductId).GetAwaiter().GetResult().Name;

                retVal.Add(transfer);
            }

            return retVal;
        }

        public void UpdatePrice(string shoppingbagId, int price)
        {
            throw new System.NotImplementedException();
        }

        //List<ShoppingBagTransfer> IShoppingBagService.GetAll()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
