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
        public string IdeatorId { get; set; }

        [BsonElement("ideatorName")]
        public string? IdeatorName { get; set; }

        [BsonElement("muid")] 
        public string? MUId { get; set; }

        [BsonElement("company")]
        public string? Company { get; set; }

        [BsonElement("officeAddress")]
        public string? OfficeAddress { get; set; }

        public Ideator()
        {
            IdeatorId = ObjectId.GenerateNewId().ToString();
        }
    }
}
