

using Customer.Interface;
using Customer.Models;
using Newtonsoft.Json;
using Shared.ViewModels;

namespace Customer.Services
{
    public class RatingService : IRatingService
    {
        private readonly IHttpClientFactory _clientFactory;
        public RatingService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<Rating>> GetRatingById(int id)
        {
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"Rating/{id}");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<Rating>>(contents);

            return data;
        }
    }
}
