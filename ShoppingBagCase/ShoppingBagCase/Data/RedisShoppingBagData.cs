using ShoppingBagCase.Models.ShoppingBag;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Text.Json;
using System;
using System.Linq;

namespace ShoppingBagCase.Data
{
    public class RedisShoppingBagData:IShoppingData
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisShoppingBagData(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void AddToShoppingBag(string productId, int price)
        {
            var newShoppingB = new ShoppingBag()
            {
                ProductId = productId,
                Price = price
            };

            var db = _redis.GetDatabase();
            var serialShoppingBag = JsonSerializer.Serialize(newShoppingB);

            db.HashSet("hashcart", new HashEntry[] { new HashEntry(newShoppingB.Id, serialShoppingBag) });
        }

        public void DeleteShoppingBag(string ShoppingBagId)
        {
            var db = _redis.GetDatabase();
            db.HashDelete("hashcart", ShoppingBagId);
        }

        public List<ShoppingBag> GetAll()
        {
            var db = _redis.GetDatabase();
            var completeSet = db.HashGetAll("hashcart");

            if (completeSet.Length > 0)
            {
                var obj = Array.ConvertAll(completeSet, val => JsonSerializer.Deserialize<ShoppingBag>(val.Value)).ToList();
                return obj;
            }

            return null;
        }

        public void UpdatePrice(string ShoppingBagId, int Price)
        {
            var shoppingbag = GetShoppingBag(ShoppingBagId);
            if (shoppingbag == null) return;

            shoppingbag.Price = Price;

            var db = _redis.GetDatabase();
            var serialCart = JsonSerializer.Serialize(shoppingbag);
            db.HashSet("hashcart", new HashEntry[] { new HashEntry(shoppingbag.Id, serialCart) });
        }

        private ShoppingBag GetShoppingBag(string ShoppingBagId)
        {
            var db = _redis.GetDatabase();
            var shoppingbag = db.HashGet("hashcart", ShoppingBagId);

            if (!string.IsNullOrEmpty(shoppingbag))
            {
                return JsonSerializer.Deserialize<ShoppingBag>(shoppingbag);
            }

            return null;
        }
    }
}
