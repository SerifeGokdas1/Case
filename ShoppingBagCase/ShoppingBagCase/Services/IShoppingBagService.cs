using ShoppingBagCase.Models.ShoppingBag;
using System.Collections.Generic;

namespace ShoppingBagCase.Services
{
    public interface IShoppingBagService
    {
        void AddToShoppingBag(string productId, int price);
        void UpdatePrice(string shoppingbagId, int price);
        void DeleteShoppingBag(string shoppingbagId);
        List<ShoppingBagTransfer> GetAll();
    }
}
