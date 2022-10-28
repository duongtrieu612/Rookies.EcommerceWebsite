using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Category Category { get; set; }
    }
}
