using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ShoppingBagCase.Models.Product
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
    }
}
