using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyNghe.Models;

namespace ShopMyNghe.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        DB_MyNgheDataContext data = new DB_MyNgheDataContext();

        public ActionResult ViewCart()
        {
            if (Session["Cart_Session"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart_Session> lstCart = GetCart();
            ViewBag.CountCart = CountCart();
            ViewBag.SumCart = SumCart();
            return View(lstCart);
        }

        public List<Cart_Session> GetCart()
        {
            List<Cart_Session> lstCart = Session["Cart_Session"] as List<Cart_Session>;
            if (lstCart == null)
            {
                lstCart = new List<Cart_Session>();
                Session["Cart_Session"] = lstCart;
            }
            return lstCart;
        }

        public ActionResult AddCart(string id)
        {
            List<Cart_Session> lstCart = GetCart();
            Cart_Session product = lstCart.Find(s => s.sproduct_id == id);
            if (product == null)
            {
                product = new Cart_Session(id);
                lstCart.Add(product);
            }
            else
            {
                product.isoLuong++;
            }
            Session["Cart_Session"] = lstCart;
            return RedirectToAction("Index", "Home");
        }

        private int CountCart()
        {
            int tsl = 0;
            List<Cart_Session> lstCart = Session["Cart_Session"] as List<Cart_Session>;
            if (lstCart != null)
            {
                tsl = lstCart.Sum(sp => sp.isoLuong);
            }
            return tsl;
        }

        private Decimal SumCart()
        {
            Decimal ttt = 0;
            List<Cart_Session> lstCart = Session["Cart_Session"] as List<Cart_Session>;
            if (lstCart != null)
            {
                ttt += lstCart.Sum(sp => sp.dtTien);
            }
            return ttt;
        }

        public ActionResult ClearCart(string id)
        {
            List<Cart_Session> lstGioHang = GetCart();
            Cart_Session sp = lstGioHang.Single(s => s.sproduct_id == id);
            if (sp != null)
            {
                lstGioHang.RemoveAll(s => s.sproduct_id == id);
                return RedirectToAction("Cart_Session");
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        //Xóa sản phẩm khỏi giỏ hàng
        //public ActionResult DeleteProductCart(string id)
        //{
        //    Cart_Session product = data..SingleOrDefault(n => n.product_id == id);
        //    if (product == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    ViewBag.ProID = product.product_id;
        //    return View(product);
        //}

        //[HttpPost, ActionName("DeleteProduct")]
        //public ActionResult XacNhanXoaPC(string id)
        //{
        //    Product product = data.Products.SingleOrDefault(n => n.product_id == id);
        //    ViewBag.ProID = product.product_id;
        //    if (product == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    data.Products.DeleteOnSubmit(product);
        //    data.SubmitChanges();
        //    return RedirectToAction("Index", "Home");
        //}

    }
}
