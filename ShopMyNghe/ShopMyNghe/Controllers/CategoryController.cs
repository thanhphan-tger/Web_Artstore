using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyNghe.Models;

namespace ShopMyNghe.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        DB_MyNgheDataContext data = new DB_MyNgheDataContext();

        public ActionResult Categorylist()
        {
            List<Category> categories = data.Categories.ToList();
            return View(categories);
        }

        //Thêm
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateCategory(Category category)
        {
            data.Categories.InsertOnSubmit(category);
            data.SubmitChanges();
            return RedirectToAction("Index", "Home");        
        }

        //Xóa
        public ActionResult DeleteCategory(string id)
        {
            Category category = data.Categories.SingleOrDefault(n => n.category_id == id);
            if (category == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.CatID = category.category_id;
            return View(category);
        }

        [HttpPost, ActionName("DeleteCategory")]
        public ActionResult XacNhanXoa(string id)
        {
            Category category = data.Categories.SingleOrDefault(n => n.category_id == id);
            ViewBag.ProID = category.category_id;
            if (category == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.Categories.DeleteOnSubmit(category);
            data.SubmitChanges();
            return RedirectToAction("Categorylist", "Category");
        }

        //Sửa
        public ActionResult EditCategory(string id)
        {
            Category category = data.Categories.Where(a => a.category_id == id).FirstOrDefault();
            if (category == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult EditProduct(Category cat)
        {
            Category category = data.Categories.Where(a => a.category_id == cat.category_id).FirstOrDefault();

            category.category_id = cat.category_id;
            category.name = cat.name;

            data.SubmitChanges();
            return RedirectToAction("Categorylist", "Category");
        }
    }
}
