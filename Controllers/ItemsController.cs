using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Bl;
using E_commerce.Models;
using Domains;
using Microsoft.AspNetCore.Authorization;

namespace E_commerce.Controllers
{
    //[Authorize]
    public class ItemsController : Controller
    {
        IItemService ItemService;
        public ItemsController(IItemService itemService)
        {
            ItemService = itemService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ItemDetailModel model = new ItemDetailModel();
            model.Item = ItemService.GetByIdWithImages(id);
            model.listRelatedItems = ItemService.GetRelatedItems(model.Item.SalesPrice);
           
            return View(model);
        }
        //[Authorize]
        public IActionResult AddToCart(int id)
        {
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            if (oShopingCart == null)
                oShopingCart = new ShopingCart();
            TbItems item = ItemService.GetById(id);
            ShopingCartItem shopingItem = oShopingCart.ListItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (shopingItem != null)
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Price * shopingItem.Qty;
            }
            else
            {
                oShopingCart.ListItems.Add(new ShopingCartItem()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ImageName = item.ImageName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice
                });
            }

            oShopingCart.Total = oShopingCart.ListItems.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);
            return Redirect("/Order/Cart");
        }

        public IActionResult ItemList()
        {
            return View();
        }
    }
}
