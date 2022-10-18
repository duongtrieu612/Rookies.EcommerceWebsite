
using CustomerSite.Models;

namespace CustomerSite.Services
{
	public interface IProductService
	{
		List<Product> GetAllProduct();
	}


	public class ProductService : IProductService
	{
		public List<Product> GetAllProduct()
		{
			// connect database
			// query products

			return new List<Product>()
			{
				new Product(){ Id = 1, Name = "Product 1", SoLuong = 10 },
				new Product(){ Id = 2, Name = "Product 2", SoLuong = 9 },
				new Product(){ Id = 3, Name = "Product 3", SoLuong = 8 }
			};
		}
	}

	public class ProductService2 : IProductService
	{
		public List<Product> GetAllProduct()
		{
			// connect other database
			// query products

			return new List<Product>()
			{
				new Product(){ Id = 1, Name = "Product 1 service 2", SoLuong = 10 },
				new Product(){ Id = 2, Name = "Product 2 service 2", SoLuong = 9 },
				new Product(){ Id = 3, Name = "Product 3 service 2", SoLuong = 8 }
			};
		}
	}
}
