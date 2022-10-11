using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Bl;
using Domains;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        ISliderService sliderService;
        ISliderCategoryService SliderCategoryService;

        public SliderController(ISliderService service, ISliderCategoryService category)
        {
            sliderService = service;
            SliderCategoryService = category;


        }

        public IActionResult ListSlider()
        {
            return View(sliderService.GetAll());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditSlider(int? id)
        {
            ViewBag.Sliders = SliderCategoryService.GetAll();
            if (id != null)
            {
                return View(sliderService.GetById(Convert.ToInt32(id)));
            }
            else
                return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int slider)
        {
            sliderService.Delete(slider);
            return RedirectToAction("ListSlider");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Save(TbSlider slider, List<IFormFile> Files)
        {

           
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Slider", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        slider.ImageName = ImageName;
                    }
                }

                if (slider.SliderId == 0)
                    sliderService.Add(slider);
                else
                    sliderService.EditSlider(slider);
                return RedirectToAction("ListSlider");
         
        }
    }
}
