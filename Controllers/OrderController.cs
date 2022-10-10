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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace E_commerce.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");

            return View(oShopingCart);
        }

        public IActionResult RemoveItem(int id)
        {
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            oShopingCart.ListItems.Remove(oShopingCart.ListItems.Where(a => a.ItemId == id).FirstOrDefault());
            oShopingCart.Total = oShopingCart.ListItems.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);
            return RedirectToAction("Cart");
        }
    }
}
