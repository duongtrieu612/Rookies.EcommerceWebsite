using CustomerSite.Interface;
using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerSite.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductService productService;

        public ProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var product = await productService.GetAllProductsAsync();

            return View("Products", product);
        }
    }

}
