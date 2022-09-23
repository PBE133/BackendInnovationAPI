using BackendInnovationAPI.DatabaseSettings;
using BackendInnovationAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;

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
        public List<Idea> GetIdeaCollections()
        {
            return _ideas.Find(_ => true).ToList();
        }

        // Post your ideas
        public Idea CreateIdeaCollection(Idea idea)
        {
            _ideas.InsertOne(idea);
            return idea;
        }

        public Idea GetIdea(string id)
        {
            return _ideas.Find(idea => idea.Id == id).FirstOrDefault();
        }



        public void Update(string id, Idea idea)
        {
            _ideas.ReplaceOne(idea => idea.Id == id, idea);
        }


        public void FetchOnlyIdeas()
        {
           var fetchall = _ideas.Find(_ => true).First();
            Console.WriteLine(fetchall);
       
       
           


        }


    }
}
