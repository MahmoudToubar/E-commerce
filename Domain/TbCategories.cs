using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{ 
    public partial class TbCategories
    {
        public TbCategories()
        {
            TbItems = new HashSet<TbItems>();
            
        }
        [Key]
        [ValidateNever]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "please enter category name")]
        public string CategoryName { get; set; } = null!;
        [ValidateNever]
        public string CreatedBy { get; set; } = null!;
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        public int CurrentState { get; set; }
        [ValidateNever]
        public string ImageName { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<TbItems> TbItems { get; set; }
    }
}
