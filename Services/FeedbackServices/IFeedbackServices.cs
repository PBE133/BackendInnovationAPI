using BackendInnovationAPI.DTO;
using BackendInnovationAPI.Models;
using System.Linq;

namespace BackendInnovationAPI.Services.FeedbackServices
{
    public interface IFeedbackServices
    {
        Task<IEnumerable<Feedback>> GetFeedback();
        Task<Feedback> CreateFeedbacks(Feedback feedback);

        Task<Feedback> GetFeedbackById(string id);

        Task<Feedback> Update(string id, Feedback feedback);

        // public List<Feedback> GetFeedbacksByIdeaID(string id);

    }
}
