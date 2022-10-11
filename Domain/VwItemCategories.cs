using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domains
{
    public partial class VwItemCategories
    {
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
