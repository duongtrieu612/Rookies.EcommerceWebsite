using Shared;

namespace CustomerSite.Interface
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();

        Task<ProductViewModel> GetProductsId(int id);
        Task<List<ProductViewModel>> SearchProduct(string searchString);
    }
}
