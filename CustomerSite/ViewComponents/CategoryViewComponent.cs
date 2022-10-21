using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerSite.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public CategoryViewComponent(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Category list = new Category();
            List<Category> categories = new List<Category>();
            HttpClient client = _clientFactory.CreateClient();
            var response = await client.GetAsync("Category");
            var contents = await response.Content.ReadAsStringAsync();

            var category = JsonConvert.DeserializeObject<List<Category>>(contents);

            return View("Category", category);
        }
    }
}
