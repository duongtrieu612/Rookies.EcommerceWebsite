using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Models
{
    public class Rating
    {
        public List<Rating> rating = new List<Rating>();
        public string Comment { get; set; }

        public DateTime DateComment { get; set; }
        public int RatingStar { get; set; }

        public int ProductId { get; set; }
    }
}
