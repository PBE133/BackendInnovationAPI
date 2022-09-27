using BackendInnovationAPI.DatabaseSettings;
using BackendInnovationAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BackendInnovationAPI.Services
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
        public async Task<IEnumerable<Idea>> GetIdeaCollections()
        {
            return await _ideas.Find(_ => true).ToListAsync();
        }

        // Get all ideas collections by ID
        public async Task<Idea> GetIdea(string id)
        {
            return await _ideas.Find(idea => idea.Id == id).FirstOrDefaultAsync();

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
          await _ideas.ReplaceOneAsync(idea => idea.Id == id, idea);
            return idea;
        }


        //Patch your idea collection
        // Undone












    }
}
