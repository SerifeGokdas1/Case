using ShoppingBagCase.Models.ShoppingBag;
using System.Collections.Generic;

namespace ShoppingBagCase.Data
{
    public interface IShoppingData
    {
        void AddToShoppingBag(string ProductId, int Price);
        void UpdatePrice(string ShoppingBagId, int Price);
        void DeleteShoppingBag(string ShoppingBagId);
        List<ShoppingBag> GetAll();
    }
}
