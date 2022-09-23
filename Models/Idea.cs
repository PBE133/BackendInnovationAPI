using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace BackendInnovationAPI.Models
{
    public class Idea
    {
       
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdatedAt { get; set; }
        public string Portfolio_id { get; set; }
        public Ideator IdeatorId { get; set; }
        public Segment SegmentId { get; set; }

        public Idea()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
