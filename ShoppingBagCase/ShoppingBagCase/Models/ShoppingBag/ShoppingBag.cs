using System;

namespace ShoppingBagCase.Models.ShoppingBag
{
    public class ShoppingBag
    {
        public string Id { get; set; } = $"cart:{Guid.NewGuid()}";
        public string ProductId { get; set; }
        public int Price { get; set; }
    }
}
