using BackendInnovationAPI.DTO;
using BackendInnovationAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;

namespace BackendInnovationAPI.Services.IdeaServices
{
    public interface IServiceIdeas
    {
        Task<IEnumerable<Idea>> GetIdeaCollections();

        //Task<IEnumerable<FeedbackIdDTO>> GetIdeaCollections();

        Task<Idea> GetIdea(string id);

        Task<Idea> CreateIdeaCollection(Idea idea);
        Task<Idea> Update(string id, Idea idea);

        public  Task <IdeaByMUId> GetIdeasByIdeatorMUID(string MUId);

      public Task< List<IdeaDTO>> FetchAndMapIdeas();



    }
}
