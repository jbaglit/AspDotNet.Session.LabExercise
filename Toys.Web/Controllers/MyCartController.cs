using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using Toys.Data.Models;
using Toys.Data.Repositories;
using Toys.Web.Extensions;
using Toys.Web.Services;


namespace Toys.Web.Controllers
{
    public class MyCartController : Controller
    {
        private readonly IToyService toyService;
        private readonly IToyRepository toyRepository;

        public MyCartController(IToyRepository toyRepository, IToyService toyService)
        {
            this.toyRepository = toyRepository;
            this.toyService = toyService;
        }

        public ActionResult Index()
        {
            if (HttpContext.Session.Get("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();

                HttpContext.Session.SetObject("cart", cart);
            }

            return View();
        }

        private int isExist(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].CToy.CToyId.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult Add(string id)
        {
            if (HttpContext.Session.GetObject<List<ShoppingCart>>("cart") == null)
            {
                List<ShoppingCart> cart = new List<ShoppingCart>();
                cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                HttpContext.Session.SetObject("cart", cart);
            }
            else
            {
                List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].SiQty++;
                }
                else
                {
                    cart.Add(new ShoppingCart { CToy = toyRepository.FindByPrimaryKey(id), SiQty = 1 });
                }
                HttpContext.Session.SetObject("cart", cart);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            List<ShoppingCart> cart = HttpContext.Session.GetObject<List<ShoppingCart>>("cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }
    }
}