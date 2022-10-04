using BackendInnovationAPI.Models;

namespace BackendInnovationAPI.DTO
{
    public class FeedbackByIdeaId
    {
        public string IdeaId { get; set; }
        public List<Feedback>Feedbacks { get; set; }
    }
}
