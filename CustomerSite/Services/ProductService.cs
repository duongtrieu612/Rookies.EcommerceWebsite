
using CustomerSite.Interface;
using CustomerSite.Models;
using Newtonsoft.Json;
using Shared;

namespace CustomerSite.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {

            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync("Products");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<ProductViewModel>>(contents);

            return data;
        }
        public async Task<ProductViewModel> GetProductsId(int id)
        {

            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"Products/{id}");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ProductViewModel>(contents);

            return data;
        }
        public async Task<List<ProductViewModel>> SearchProduct(string searchString)
        {
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"Products/{searchString}");
            var contents = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<ProductViewModel>>(contents);

            return data;
        }
    }
}
