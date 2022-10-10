using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BackendInnovationAPI.Models
{
    public class Portfolio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string PortfolioId { get; set; } 

        [BsonElement("portfolioName")]
        public string? PortfolioName { get; set; }

        [BsonElement("portfolioCode")]
        public string? PortfolioCode { get; set; }

        [BsonElement("value")]
        public double? Value { get; set; }

        public Portfolio()
        {
            PortfolioId = ObjectId.GenerateNewId().ToString();
        }
    }
}
