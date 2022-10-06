using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace BackendInnovationAPI.Models
{
    public class Score
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ScoreId { get; set; }

        [Range(1, 100, ErrorMessage = "Price must be between $1 and $100")]

        public double Scale { get; set; }

        public double Cost { get; set; }

        public Score()
        {
            ScoreId = ObjectId.GenerateNewId().ToString();
        }
    }
}
