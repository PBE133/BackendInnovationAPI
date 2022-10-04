using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace BackendInnovationAPI.Models
{
    public class Idea
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

        //public List<string> FeedbackId { get; set; }
        public List<Feedback> Feedbacks { get; set; }

        /*
      [BsonElement("Portfolio")]
      public Portfolio Portfolio { get; set; }

      [BsonElement("Score")]
      public Score Score { get; set; }
      */

        public Idea()
        {
            IdeaId = ObjectId.GenerateNewId().ToString();
        }
    }
}
