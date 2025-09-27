using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinalApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("category")]
        public string Category { get; set; } = string.Empty;
    }
}
