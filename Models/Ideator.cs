using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace BackendInnovationAPI.Models
{
    public class Ideator
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        [BsonElement("ideatorId")]
        public string? IdeatorId { get; set; }

        [BsonElement("ideatorName")]
        [Required(ErrorMessage = "Ideator Name is required")]
        public string IdeatorName { get; set; }

        [BsonElement("muid")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "This field must be 6 characters")]
        [RegularExpression("^(?=.*[A-Z])(?=.*[0-9])[A-Z0-9]*$")]
        [Required]
        public string? MUId { get; set; }

        [BsonElement("company")]
        public string? Company { get; set; }

        [BsonElement("officeAddress")]
        public string? OfficeAddress { get; set; }

        public Ideator()
        {
            IdeatorId = ObjectId.GenerateNewId().ToString();
        }
    }
}
