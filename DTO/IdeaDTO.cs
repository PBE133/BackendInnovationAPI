using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendInnovationAPI.DTO
{
    public class IdeaDTO
    {
        [BsonElement("muid")]
        public string MuId { get; set; }

        [BsonElement("ideaName")]
        public string? IdeaName { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

    }
}
