using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace E_commerce.Models
{
    public class HomePageModel
    {
        public IEnumerable<TbSlider> lstSliderImages { get; set; }
      
        public IEnumerable<TbItems> lstAllItems { get; set; }
        public IEnumerable<TbItems> lstCategories { get; set; }
        public IEnumerable<TbSlider> lstSliderCategories { get; set; }
     
        
    }
}
