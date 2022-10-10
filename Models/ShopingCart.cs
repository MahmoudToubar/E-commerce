using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class ShopingCart
    {
        public ShopingCart()
        {
            ListItems = new List<ShopingCartItem>();
        }
        public List<ShopingCartItem> ListItems { get; set; }

        public decimal Total { get; set; }
    }
}
