using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackendInnovationAPI.Models
{
    public class Feedback
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string? Value { get; set; }


        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Unspecified)]
        public DateTime UpdatedAt { get; set; }

        public Segment SegmentId { get; set; }
        public Idea IdeaId { get; set; }


        public Feedback()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

    }
}
