using BackendInnovationAPI.DatabaseSettings;
using BackendInnovationAPI.DTO;
using BackendInnovationAPI.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BackendInnovationAPI.Services.IdeaServices
{
    public class ServiceIdeas : IServiceIdeas
    {
        private readonly IMongoCollection<Idea> _ideas;


        public ServiceIdeas(IDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);

            _ideas = database.GetCollection<Idea>("Ideas");


        }
        // Get all ideas collections
        public async Task<IEnumerable<ListOfSegementsIdsDTO>> GetIdeaCollections()
        {
            //return await _ideas.Find(_ => true).ToListAsync();


            
            var ideasCollection = await _ideas.Find(_ => true).ToListAsync();

            var myidea = ideasCollection.Select(_ => new ListOfSegementsIdsDTO()
            {
                IdeaId = _.IdeaId,
                IdeaName = _.IdeaName,
                Description = _.Description,
                CreatedAt = _.CreatedAt,
                UpdatedAt = _.UpdatedAt,
                Ideator = _.Ideator,
                Feedback_value = _.FeedBack_value,               
                SegmentsIds = _.Segment.Select(x => x.SegmentId).ToList(),
                PortfolioName = _.Portfolio?.PortfolioName
            });
            return myidea;

            

        }

        // Get all ideas collections by ID
        public async Task<Idea> GetIdea(string id)
        {
            return await _ideas.Find(idea => idea.IdeaId == id).FirstOrDefaultAsync();

        }

        public async Task<List<IdeaDTO>> FetchAndMapIdeas()
        {
            var ideas = await _ideas.Find(_ => true)
                                    .ToListAsync();

            var mapProperties = ideas.Select(_ => new IdeaDTO()
            {
                MuId = _.Ideator.MUId,
                IdeaName = _.IdeaName,
                Description = _.Description,
               

            }).ToList();

            return mapProperties;
        }


        // Post your ideas
  
        public async Task<Idea> CreateIdeaCollection(Idea idea)
        {
            await _ideas.InsertOneAsync(idea);
            return idea;


        }
  

        // Put your ideas
        public async Task<Idea> Update(string id, Idea idea)
        {
            await _ideas.ReplaceOneAsync(idea => idea.IdeaId == id, idea);
            return idea;
        }

        public async Task<IdeaByMUId> GetIdeasByIdeatorMUID(string MUId)
        {

            var foundMuid = await _ideas.Find(_ => _.Ideator.MUId == MUId).FirstOrDefaultAsync();

            List<Idea> AllIdeas = new List<Idea>();
            IdeaByMUId ideaByMUId = new IdeaByMUId();
            if (foundMuid is not null)
            {
                AllIdeas = _ideas.Find(_ => _.Ideator.IdeatorId == foundMuid.Ideator.IdeatorId).ToList();


                return new IdeaByMUId()
                {
                    Ideas = AllIdeas,
                    MUId = foundMuid.Ideator.MUId

                };


            }
            return ideaByMUId;
        }

       

       
    }
}
