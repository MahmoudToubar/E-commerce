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
    [Area("admin")]
    public class CategoriesController : Controller
    {
        public CategoriesController(ICategoryService category)
        {
            categoryService = category;
        }
        ICategoryService categoryService;
        public IActionResult ListCat()
        {
            return View(categoryService.GetAll());
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EditCat(int? categoryId)
        {
            var category = new TbCategories();
            if (categoryId != null)
            {
                category = categoryService.GetById(Convert.ToInt32(categoryId));
            }
            return View(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCategories category, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
                return View("EditCat", category);



            categoryService.Save(category);

            return RedirectToAction("ListCat");
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int categoryId)
        {
            categoryService.Delete(categoryId);
            return RedirectToAction("ListCat");
        }


    }
}
