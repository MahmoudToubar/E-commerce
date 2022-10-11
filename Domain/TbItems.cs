using Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbItems
    {
        public TbItems()
        {
           
            TbItemImages = new HashSet<TbItemImages>();
           
        }
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please enter Sales Price")]
        public decimal SalesPrice { get; set; }
        [Required(ErrorMessage = "Please enter Purchase Price")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "Please select Category")]
        public int CategoryId { get; set; }
        [MaxLength(200)]
        public string ImageName { get; set; }
        public DateTime CreationDate { get; set; }
        public int CurrentState { get; set; }

        public virtual TbCategories Category { get; set; }
      
        public virtual ICollection<TbItemImages> TbItemImages { get; set; }
 
    }
}
