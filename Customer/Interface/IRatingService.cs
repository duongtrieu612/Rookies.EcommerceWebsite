using Customer.Models;

namespace Customer.Interface
{
    public interface IRatingService
    {
        Task<List<Rating>> GetRatingById(int id);
    }
}
