using E_commerce.Bl;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace E_commerce.Controllers
{
    public class HomeController : Controller
    {
        IItemService itemService;
        ISliderService sliderService;
        public HomeController(IItemService item , ISliderService slider)
        {
            itemService = item;
            sliderService = slider;
        }

        
        
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstAllItems = itemService.GetAll();

            

            model.lstSliderImages = sliderService.GetAll();
            model.lstSliderCategories = model.lstSliderImages.GroupBy(a => a.CatSliderId).Select(a => a.FirstOrDefault()).ToList();

            model.lstCategories =
            model.lstAllItems.GroupBy(a => a.CategoryId).Select(a => a.First()).ToList();
            return View(model);
        }
    }
}
