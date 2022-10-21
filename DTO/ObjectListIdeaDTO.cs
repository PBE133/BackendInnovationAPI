using BackendInnovationAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendInnovationAPI.DTO
{
    public class ListOfSegementsIdsDTO
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

        [BsonElement("Feedback_name")]
        public string Feedback { get; set; }

        public List<string> SegmentsIds { get; set; }

        public string? PortfolioName { get; set; }


    }

}
