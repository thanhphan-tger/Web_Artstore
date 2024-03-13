using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyNghe.Models;
using System.IO;

namespace ShopMyNghe.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        DB_MyNgheDataContext data = new DB_MyNgheDataContext();

        public ActionResult ProductsByCategory(string id)
        {
            List<Product> products = data.Products.Where(r => r.category_id.Contains(id)).ToList();
            ViewBag.CatId = id;
            return View(products);
        }

        public ActionResult ProductDetails(string id)
        {
            Product product = data.Products.SingleOrDefault(n => n.product_id == id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }

        public ActionResult CreateProduct()
        {
            ViewBag.category_id = new SelectList(data.Categories.ToList().OrderBy(n => n.name), "category_id", "name");
            ViewBag.source_id = new SelectList(data.Sources.ToList().OrderBy(n => n.name), "source_id", "name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase fileupload)
        {
            ViewBag.category_id = new SelectList(data.Categories.ToList().OrderBy(n => n.name), "category_id", "name");
            ViewBag.source_id = new SelectList(data.Sources.ToList().OrderBy(n => n.name), "source_id", "name");
            if (fileupload == null)
            {
                ViewBag.thongbao = "Chon anh bia";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/img/ProIMG"), fileName);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Anh da ton tai";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    product.Images = fileName;
                    data.Products.InsertOnSubmit(product);
                    data.SubmitChanges();
                }
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DeleteProduct(string id)
        {
            Product product = data.Products.SingleOrDefault(n => n.product_id == id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.ProID = product.product_id;
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult XacNhanXoa(string id)
        {
            Product product = data.Products.SingleOrDefault(n => n.product_id == id);
            ViewBag.ProID = product.product_id;
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.Products.DeleteOnSubmit(product);
            data.SubmitChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditProduct(string id)
        {
            ViewBag.category_id = new SelectList(data.Categories.ToList().OrderBy(n => n.name), "category_id", "name");
            ViewBag.source_id = new SelectList(data.Sources.ToList().OrderBy(n => n.name), "source_id", "name");
            Product product = data.Products.Where(a => a.product_id == id).FirstOrDefault();
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product pro)
        {
            ViewBag.category_id = new SelectList(data.Categories.ToList().OrderBy(n => n.name), "category_id", "name");
            ViewBag.source_id = new SelectList(data.Sources.ToList().OrderBy(n => n.name), "source_id", "name");
            Product product = data.Products.Where(a => a.product_id == pro.product_id).FirstOrDefault();
            
            product.product_id = pro.product_id;
            product.name = pro.name;
            product.price = pro.price;
            product.description = pro.description;
            product.category_id = pro.category_id;
            product.source_id = pro.source_id;

            data.SubmitChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
