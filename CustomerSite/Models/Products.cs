using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSite.Models
{
    public class Product
    {
        public List<Product> product = new List<Product>();
        public int Id { get; set; }

        public string Name { get; set; }

        public int SoLuong { get; set; }
    }
}
