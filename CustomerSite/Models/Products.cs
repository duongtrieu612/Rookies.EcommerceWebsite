using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerSite.Models
{
    public class Product
    {
        public List<Product> product = new List<Product>();
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        public string Image { get; set; }

        public virtual Category Category { get; set; }
    }
}
