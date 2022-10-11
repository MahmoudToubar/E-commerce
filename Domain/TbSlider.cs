using Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSlider
    {
       
        [Key]
        public int SliderId { get; set; }
        
        public string ImageName { get; set; }
        public int CatSliderId { get; set; }

        public virtual TbSliderCategory SliderCategory { get; set; }
        
    }
}
