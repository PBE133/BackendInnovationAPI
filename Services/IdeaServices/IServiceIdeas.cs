using BackendInnovationAPI.DTO;
using BackendInnovationAPI.Models;

namespace BackendInnovationAPI.Services.IdeaServices
{
    public interface IServiceIdeas
    {
       //Task<IEnumerable<Idea>> GetIdeaCollections();

        Task<IEnumerable<ListOfSegementsIdsDTO>> GetIdeaCollections();

        Task<Idea> GetIdea(string id);

       Task<Idea> CreateIdeaCollection(Idea idea);
        Task<Idea> Update(string id, Idea idea);

        public Task<IdeaByMUId> GetIdeasByIdeatorMUID(string MUId);

        public Task<List<IdeaDTO>> FetchAndMapIdeas();



    }
}
