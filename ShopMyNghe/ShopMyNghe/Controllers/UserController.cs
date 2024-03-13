using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyNghe.Models;

namespace ShopMyNghe.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        DB_MyNgheDataContext data = new DB_MyNgheDataContext();

        [ChildActionOnly]
        public ActionResult RenderUserName()
        {
            ViewBag.UrN = Session["UrN"];
            ViewBag.UrID = Session["UrID"];
            return PartialView("_UserName");
        }

        //Đăng nhập
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HandleLogin(FormCollection c)
        {
            string Email = c["txtEmail"];
            string Pass = c["txtPass"];
            User Ur = data.Users.SingleOrDefault(t => t.email == Email && t.password == Pass);
            if (Ur == null)
            {
                ViewBag.Err = "Sai thong tin!";
                return RedirectToAction("Login");
            }
            else
                Session["User"] = Ur;
            Session["UrID"] = Ur.user_id;
            Session["UrN"] = Ur.username;
            return RedirectToAction("Index", "Home");
        }

        //Đăng ký
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationProcessing(User Ur)
        {
            if (Ur == null)
            {
                return RedirectToAction("Register", "User");
            }
            data.Users.InsertOnSubmit(Ur);
            data.SubmitChanges();
            return RedirectToAction("Login", "User");
        }

        //Đăng xuất
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }
       
        //Xem thông tin chi tiết User 
        public ActionResult UserInformation()
        {
            string id = Session["UrID"].ToString();
            User Ur = data.Users.SingleOrDefault(a => a.user_id == id);
            return View(Ur);
        }

        //Sửa thông tin User
        public ActionResult EditUser()
        {
            string id = Session["UrID"].ToString();
            User Ur = data.Users.SingleOrDefault(a => a.user_id == id);
            if (Ur == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(Ur);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProcessingEditUser(User Ur)
        {
            if (Ur == null)
            {
                return RedirectToAction("Index", "Home");
            }
            UpdateModel(Ur);
            data.SubmitChanges();
            return RedirectToAction("UserInformation", "User");
        }
    }
}
