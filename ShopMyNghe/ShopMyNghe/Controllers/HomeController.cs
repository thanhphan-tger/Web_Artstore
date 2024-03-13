using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyNghe.Models;

namespace ShopMyNghe.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DB_MyNgheDataContext data = new DB_MyNgheDataContext();

        public ActionResult Index(string search = "")
        {
            List<Product> products = data.Products.Where(r => r.name.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            List<Category> categories = data.Categories.ToList();
            ViewBag.Categories = categories;

            return PartialView("_Menu");
        }

    }
}
