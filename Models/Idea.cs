using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BackendInnovationAPI.Models
{
    public class Idea
    {
       
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdeaId { get; set; }

        [BsonElement("ideaName")]
        [Required(ErrorMessage = "Idea Name is required")]
        public string IdeaName { get; set; }

        [BsonElement("description")]
        [StringLength(200, MinimumLength = 80, ErrorMessage = "This field must be more than  80 characters")]
        [Required]
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
