using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Bl
{
    public interface ISliderService
    {


        List<VwSliderCategories> GetAllSlider();
        List<TbSlider> GetAll();
        TbSlider GetById(int id);
        
        bool Add(TbSlider slider);
        bool EditSlider(TbSlider slider);
        bool Delete(int sliderId);
    }
    public class ClsSlider : ISliderService
    {
        EcommerceContext ctx;
        public ClsSlider(EcommerceContext context)
        {
            ctx = context;
        }

        public bool Add(TbSlider slider)
        {
            try
            {
                ctx.Add<TbSlider>(slider);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int sliderId)
        {
            try
            {
                TbSlider OldSlider = ctx.TbSlider.Where(a => a.SliderId == sliderId).FirstOrDefault();
                ctx.TbSlider.Remove(OldSlider);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditSlider(TbSlider slider)
        {
            try
            {
                
                ctx.Entry(slider).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TbSlider> GetAll()
        {
            List<TbSlider> lstSlider = ctx.TbSlider.Include(a => a.SliderCategory).ToList();
            return lstSlider;
        }

        public List<VwSliderCategories> GetAllSlider()
        {
            List<VwSliderCategories> lstSlider = ctx.VwSliderCategories.ToList();
            return lstSlider;
        }

        public TbSlider GetById(int id)
        {
            TbSlider slider = ctx.TbSlider.FirstOrDefault(a => a.SliderId == id);
            return slider;
        }

        
    }
}
