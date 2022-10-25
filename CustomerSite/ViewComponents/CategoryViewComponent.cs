using CustomerSite.Interface;
using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerSite.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoryViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var category = await categoryService.GetAllCategory();

            return View("Category", category);
        }
    }
}
