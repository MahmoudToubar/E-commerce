using Domains;
using E_commerce.Bl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    
    public class ItemsController : Controller
    {
        IItemService itemService;
        ICategoryService categoryService;
        public ItemsController(IItemService service, ICategoryService category)
        {
            itemService = service;
            categoryService = category;
        }
        public IActionResult List()
        {
            return View(itemService.GetAll());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            ViewBag.Categories = categoryService.GetAll();
            if (id != null)
            {
                return View(itemService.GetById(Convert.ToInt32(id)));
            }
            else
                return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int item)
        {
            itemService.Delete(item);
            return RedirectToAction("List");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Save(TbItems item, List<IFormFile> Files)
        {
           
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        item.ImageName = ImageName;
                    }
                }

                if (item.ItemId == 0)
                    itemService.Add(item);
                else
                    itemService.Edit(item);
                return RedirectToAction("List");
         
        }
    }
}
