using BackendInnovationAPI.DatabaseSettings;
using BackendInnovationAPI.DTO;
using BackendInnovationAPI.Models;
using MongoDB.Driver;
using Org.BouncyCastle.Crypto;

namespace BackendInnovationAPI.Services.FeedbackServices
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IMongoCollection<Feedback> _feedbacks;
        private readonly IMongoCollection<Idea> _ideas;

        public FeedbackServices(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _feedbacks = database.GetCollection<Feedback>("Feedbacks");
            // _ideas = database.GetCollection<Idea>("Ideas");
        }



        public async Task<IEnumerable<Feedback>> GetFeedback()
        {
            return _feedbacks.Find(_ => true).ToList();

        }

        public async Task<Feedback> CreateFeedbacks(Feedback feedback)
        {
            await _feedbacks.InsertOneAsync(feedback);
            return feedback;

        }

        public async Task<Feedback> GetFeedbackById(string id)
        {
           return await _feedbacks.Find(_ => _.FeedbackId == id).FirstOrDefaultAsync();
        }

        public async Task<Feedback> Update(string id, Feedback feedback)
        {
            await _feedbacks.ReplaceOneAsync(feed=> feed.FeedbackId == id, feedback);
            return feedback;


        }

        /*
        public List<Feedback> GetFeedbacksByIdeaID(string id)
        {
            var foundIdea = _ideas.Find(_ => _.IdeaId == id).First();
            return foundIdea.Feedbacks; ;
          
        }
        */



    }
}
