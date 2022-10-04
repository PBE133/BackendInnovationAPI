using BackendInnovationAPI.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackendInnovationAPI.DTO
{
    public class FeedbackIdDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdeaId { get; set; }

        [BsonElement("ideaName")]
        public string? IdeaName { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("Ideator")]
        public Ideator Ideator { get; set; }

        [BsonElement("Segment")]
        public Segment Segments { get; set; }

        public List<string> FeedbackIds { get; set; }
    }
}
