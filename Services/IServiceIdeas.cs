using BackendInnovationAPI.Models;

namespace BackendInnovationAPI.Services
{
    public interface IServiceIdeas
    {
        List<Idea> GetIdeaCollections();

        Idea GetIdea(string id);

        Idea CreateIdeaCollection(Idea idea);

        void Update(string id, Idea idea);

        void FetchOnlyIdeas();
    }
}
