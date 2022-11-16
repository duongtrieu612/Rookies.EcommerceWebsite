using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class RatingViewModel
    {
        public string Comment { get; set; }

        public DateTime DateComment { get; set; }
        public int RatingStar { get; set; }

        public int ProductId { get; set; }
        public List<RatingViewModel> rating = new List<RatingViewModel>();
    }
}
