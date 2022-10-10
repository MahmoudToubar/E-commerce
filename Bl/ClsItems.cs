using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Bl
{
    public interface IItemService
    {
        List<TbItems> GetAll();
        List<VwItemCategories> GetAllItems();
        List<TbItems> GetRelatedItems(decimal price);
     
        TbItems GetById(int id);
        TbItems GetByIdWithImages(int id);
        bool Add(TbItems item);
        bool Edit(TbItems item);
        bool Delete(int itemId);
    }


    public class ClsItems : IItemService
    {
        EcommerceContext ctx;
        public ClsItems(EcommerceContext context)
        {
            ctx = context;
        }
     
        public List<TbItems> GetAll()
        {
            List<TbItems> lstItems = ctx.TbItems.Include(a => a.Category).
            OrderByDescending(a => a.CreationDate).ToList();
            return lstItems;
        }

        public List<VwItemCategories> GetAllItems()
        {
            List<VwItemCategories> lstItems = ctx.VwItemCategories.ToList();
            return lstItems;
        }

   
        public List<TbItems> GetRelatedItems(decimal price)
        {
            decimal start = price - 2000;
            decimal end = price + 2000;
            List<TbItems> lstItems = ctx.TbItems.Include(a => a.Category).Where(a => a.SalesPrice >= start && a.SalesPrice <= end).
            OrderByDescending(a => a.CreationDate).ToList();
            return lstItems;
        }

        public TbItems GetById(int id)
        {
            TbItems item = ctx.TbItems.FirstOrDefault(a => a.ItemId == id);
            return item;
        }

        public TbItems GetByIdWithImages(int id)
        {
            try
            {
                TbItems item = ctx.TbItems.Include(a => a.TbItemImages).FirstOrDefault(a => a.ItemId == id);
                return item;
            }
            catch (Exception ex)
            {
                return new TbItems();
            }

        }

        public bool Add(TbItems item)
        {
            try
            {
                ctx.Add<TbItems>(item);
               
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(TbItems item)
        {
            try
            {
              
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int itemId)
        {
            try
            {
                TbItems OldItem = ctx.TbItems.Where(a => a.ItemId == itemId).FirstOrDefault();
                ctx.TbItems.Remove(OldItem);
              
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
