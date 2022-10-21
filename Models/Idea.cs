using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        [StringLength(512, MinimumLength = 80, ErrorMessage = "This field must be more than  80 characters")]
        [Required]
        public string? Description { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdatedAt { get; set; }

        [BsonElement("Ideator")]
        public Ideator Ideator { get; set; }

        [BsonElement("Feedback_Name")]
        public string Feedback { get; set; }

        
        [BsonElement("SegmentIds")]
        public List<Segment> Segment { get; set; }
        //public Segment Segment { get; set; }

        [BsonElement("Portfolio")]
        public Portfolio Portfolio { get; set; }
        /*
      [BsonElement("Score")]
      public Score Score { get; set; }
      */

        public Idea()
        {
            IdeaId = ObjectId.GenerateNewId().ToString();
        }
    }
}
