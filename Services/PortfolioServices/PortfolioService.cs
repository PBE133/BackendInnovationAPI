using BackendInnovationAPI.DatabaseSettings;
using BackendInnovationAPI.Models;
using MongoDB.Driver;

namespace BackendInnovationAPI.Services.PortfolioServices
{
    public class PortfolioService : IPortfolioService
    {

        private readonly IMongoCollection<Portfolio> _portfolio;

        public PortfolioService(IDatabaseSettings settings , IMongoClient mongoClient)
        {
           var database = mongoClient.GetDatabase(settings.DatabaseName);
            _portfolio = database.GetCollection<Portfolio>("Portfolios");
        }
        public async Task<IEnumerable<Portfolio>> GetPortfolio()
        {
            return await _portfolio.Find(_ => true).ToListAsync();
        }

        public async Task<Portfolio> GetPortfolio(string id)
        {
            var byId = await _portfolio.Find(_ => _.PortfolioId == id).FirstOrDefaultAsync();
            return byId;    
        }

        public async Task<Portfolio> PostPortfolio(Portfolio portfolio)
        { 
            await _portfolio.InsertOneAsync(portfolio);
            return portfolio;
            
        }
    }
}
