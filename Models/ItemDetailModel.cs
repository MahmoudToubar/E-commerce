using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class ItemDetailModel
    {
        public TbItems Item { get; set; }
        public List<TbItems> listRelatedItems { get; set; }
        public List<TbItems> listUpSellItems { get; set; }
    }
}
