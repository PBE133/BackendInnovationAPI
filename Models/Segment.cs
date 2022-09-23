
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackendInnovationAPI.Models
{
    public class Segment
    {

      //  [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string? Name { get; set; }
        public double Value { get; set; }

        public Segment()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

    }
}
