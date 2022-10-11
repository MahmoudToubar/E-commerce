using Domains;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Bl
{
    
    public interface ISliderCategoryService
    {
        List<TbSliderCategory> GetAll();
    }
    public class ClsSliderCategories : ISliderCategoryService
    {
        EcommerceContext ctx;
        public ClsSliderCategories(EcommerceContext context)
        {
            ctx = context;
        }
        public List<TbSliderCategory> GetAll()
        {
            return ctx.TbSliderCategories.ToList();
        }
    }
}
