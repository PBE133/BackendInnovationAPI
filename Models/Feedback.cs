using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BackendInnovationAPI.DTO;

namespace BackendInnovationAPI.Models
{
    public class Feedback
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeedbackId { get; set; }

        [BsonElement("feedbackName")]
        public string? Value { get; set; }


        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; } 

        public Segment Segments { get; set; }



        public Feedback()
        {
            FeedbackId = ObjectId.GenerateNewId().ToString();
        }
    }
}
