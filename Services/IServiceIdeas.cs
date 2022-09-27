using BackendInnovationAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;

namespace BackendInnovationAPI.Services
{
    public interface IServiceIdeas
    {
        Task<IEnumerable<Idea>> GetIdeaCollections();

        Task<Idea> GetIdea(string id);

        Task<Idea> CreateIdeaCollection(Idea idea);
        Task<Idea> Update(string id, Idea idea);


       // List<Idea> UpdateEmployeePatchAsync(string id, JsonPatchDocument ideaPatch);


    }
}
