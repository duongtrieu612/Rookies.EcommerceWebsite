using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Comment { get; set; }

        public DateTime DateComment { get; set; }

        public int RatingStar { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}
