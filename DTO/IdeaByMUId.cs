using BackendInnovationAPI.Models;

namespace BackendInnovationAPI.DTO
{
    public class IdeaByMUId
    {
        public string MUId { get; set; }
        public List<Idea> Ideas { get; set; }

    }
}
