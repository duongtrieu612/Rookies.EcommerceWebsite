using Shared.ViewModels;

namespace CustomerSite.Interface
{
    public interface IRatingService
    {
        Task<List<RatingViewModel>> GetRatingById(int id);
        Task<RatingViewModel> AddRating(RatingViewModel ratingViewModel);
    }
}
