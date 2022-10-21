
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendInnovationAPI.Models
{
    public class Segment
    {

        //  [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SegmentId { get; set; }

        [BsonElement("segmentName")]
        public string SegmentName { get; set; }

        public double Value { get; set; }

        public Segment()
        {
            SegmentId = ObjectId.GenerateNewId().ToString();
        }

    }
}
