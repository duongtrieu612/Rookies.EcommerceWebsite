using Customer.Interface;
using Customer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Customer.ViewComponents
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
