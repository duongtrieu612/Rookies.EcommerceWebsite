using Customer.Models;
using Newtonsoft.Json;

namespace Customer.Clients
{
	public interface IProductClient
	{
		Task<List<Product>> GetAllProduct();
	}

	public class ProductClient : BaseClient, IProductClient
	{
		public ProductClient(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
		{
			
		}

		//public ProductClient(IHttpClientFactory clientFactory) : base(clientFactory)
		//{
		//}

		public async Task<List<Product>> GetAllProduct()
		{
			string baseUrl = "https://localhost:7067";
			var response = await httpClient.GetAsync(baseUrl + "api/Products");
			var contents = await response.Content.ReadAsStringAsync();

			var products = JsonConvert.DeserializeObject<List<Product>>(contents);

			return products ?? new List<Product>();
		}
	}
}
