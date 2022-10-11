using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using E_commerce.Bl;
using E_commerce.Models;

namespace E_commerce.Bl
{
    public interface ICategoryService
    {
        List<TbCategories> GetAll();
        public TbCategories GetById(int id);
        public bool Save(TbCategories category);
        public bool Delete(int id);
    }

    public class ClsCategories : ICategoryService
    {
        EcommerceContext ctx;
        public ClsCategories(EcommerceContext context)
        {
            ctx = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var category = GetById(id);
                category.CurrentState = 1;
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TbCategories> GetAll()
        {
            try
            {
                var lstCategories = ctx.TbCategories.Where(a => a.CurrentState == 0).ToList();
                return lstCategories;
            }
            catch
            {
                return new List<TbCategories>();
            }
        }

        public TbCategories GetById(int id)
        {
            try
            {
                var category = ctx.TbCategories.FirstOrDefault(a => a.CategoryId == id && a.CurrentState == 0);
                return category;
            }
            catch
            {
                return new TbCategories();
            }
        }

        public bool Save(TbCategories category)
        {
            try
            {
                if (category.CategoryId == 0)
                {
                    category.CreatedBy = "1";
                    category.CreatedDate = DateTime.Now;
                    ctx.TbCategories.Add(category);
                }
                else
                {
                    category.UpdatedBy = "1";
                    category.UpdatedDate = DateTime.Now;
                    ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

       






    }
}





