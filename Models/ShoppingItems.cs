using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShoppingApi.Models
{
    public class ShoppingItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("purchased")]
        public bool Purchased { get; set; } = false;

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("categoryId")]
        public string? CategoryId { get; set; } 
    }
}
