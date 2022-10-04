using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackendInnovationAPI.DTO
{
    public class IdeaDTO
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
    }
}
