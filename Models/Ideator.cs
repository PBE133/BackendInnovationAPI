using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackendInnovationAPI.Models
{
    public class Ideator
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("ideatorId")]
        public string Id { get; set; }

        public string? Name { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("company")]
        public string? Company { get; set; }

        public Ideator()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
