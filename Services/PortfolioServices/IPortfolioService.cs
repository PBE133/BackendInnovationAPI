using BackendInnovationAPI.Models;

namespace BackendInnovationAPI.Services.PortfolioServices
{
    public interface IPortfolioService
    {

        Task<IEnumerable<Portfolio>> GetPortfolio();

        Task<Portfolio> GetPortfolio(string id);

        Task<Portfolio> PostPortfolio(Portfolio portfolio);

    }
}
