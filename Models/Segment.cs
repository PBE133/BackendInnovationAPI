
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BackendInnovationAPI.DTO;

namespace BackendInnovationAPI.Models
{
    public class Segment
    {

      //  [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SegmentId { get; set; }

        [BsonElement("segmentName")]
        public List<string> SegmentName { get; set; }

      //  public double Value { get; set; }

        public Segment()
        {
            SegmentId = ObjectId.GenerateNewId().ToString();
        }

    }
}
