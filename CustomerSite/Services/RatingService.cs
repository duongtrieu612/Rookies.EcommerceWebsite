using CustomerSite.Interface;
using Newtonsoft.Json;
using Shared.ViewModels;
using System.Text;

namespace CustomerSite.Services
{
    public class RatingService : IRatingService
    {
        private readonly IHttpClientFactory _clientFactory;
        public RatingService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<RatingViewModel>> GetRatingById(int id)
        {
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"Rating/{id}");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<RatingViewModel>>(contents);

            return data;
        }
        public async Task<RatingViewModel> AddRating(RatingViewModel ratingViewModel)
        {
            HttpClient client = _clientFactory.CreateClient();

            var response = await client.PostAsJsonAsync($"Rating", ratingViewModel);
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<RatingViewModel>(contents);

            return data;
        }
    }
}
