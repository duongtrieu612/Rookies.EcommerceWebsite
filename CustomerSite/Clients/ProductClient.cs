using Newtonsoft.Json;
using Shared;

namespace CustomerSite.Clients
{
	public interface IProductClient
	{
		Task<List<ProductViewModel>> GetAllProduct();
	}

	public class ProductClient : BaseClient, IProductClient
	{
		public ProductClient(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
		{
			
		}

		//public ProductClient(IHttpClientFactory clientFactory) : base(clientFactory)
		//{
		//}

		public async Task<List<ProductViewModel>> GetAllProduct()
		{
			string baseUrl = "https://localhost:7067";
			var response = await httpClient.GetAsync(baseUrl + "api/Products");
			var contents = await response.Content.ReadAsStringAsync();

			var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(contents);

			return products ?? new List<ProductViewModel>();
		}
	}
}
