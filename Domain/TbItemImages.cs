using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbItemImages
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int ItemId { get; set; }

        public virtual TbItems Item { get; set; }
    }
}
