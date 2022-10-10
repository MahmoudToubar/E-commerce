using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class TbSliderCategory
    {
        public TbSliderCategory()
        {
            TbSlider = new HashSet<TbSlider>();
        }
        [Key]
        public int CatSliderId { get; set; }
        public string CategorySliderName { get; set; }

        public virtual ICollection<TbSlider> TbSlider { get; set; }
    }
}
