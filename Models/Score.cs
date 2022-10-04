using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackendInnovationAPI.Models
{
    public class Score
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ScoreId { get; set; }

        public double Scale { get; set; }

        public double Cost { get; set; }

        public Score()
        {
            ScoreId = ObjectId.GenerateNewId().ToString();
        }
    }
}
