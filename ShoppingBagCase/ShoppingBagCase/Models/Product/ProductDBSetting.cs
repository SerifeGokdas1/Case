using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBagCase.Models
{
    public class ProductDBSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ProductsCollectionName { get; set; } = null!;
    }
}
