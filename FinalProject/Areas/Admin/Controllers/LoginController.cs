using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.common;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Request.Cookies["Username"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.Username = Request.Cookies["Username"].Value;
                ViewBag.password = Request.Cookies["password"].Value;
            }
            return View();
        }

        public void ghinhotaikhoan(string Username, string password)
        {
            HttpCookie us = new HttpCookie("Username");
            HttpCookie pass = new HttpCookie("password");

            us.Value = Username;
            pass.Value = password;

            us.Expires = DateTime.Now.AddDays(1);
            pass.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(us);
            Response.Cookies.Add(pass);
        }

        [HttpPost]
        public ActionResult kiemtradangnhap(string Username, string password, string ghinhodangnhap)
        {
            if (Request.Cookies["Username"] != null && Request.Cookies["password"] != null)
            {
                Username = Request.Cookies["Username"].Value;
                password = Request.Cookies["password"].Value;
            }

            if (checkpassword(Username, password))
            {
                var userSession = new UserLogin();
                userSession.UserName = Username;

                var listGroups = GetListGroupID(Username);
                Session.Add("SESSION_GROUP", listGroups);
                Session.Add("USER_SESSION", userSession);

                if (ghinhodangnhap == "on")//Ghi nhớ
                    ghinhotaikhoan(Username, password);
                return Redirect("~/Admin/HomeAdmin/Dashboard");
            }
            return Redirect("~/Admin/Login");
        }

        public List<string> GetListGroupID(string userName)
        {
            var data = (from a in db.UserGroups
                        join b in db.Users on a.MaGroup equals b.MaGroup
                        where b.Username == userName

                        select new
                        {
                            UserGroupID = b.MaGroup,
                            UserGroupName = a.TenGroup
                        });
            return data.Select(x => x.UserGroupName).ToList(); ;
        }

        public bool checkpassword(string Username, string password)
        {
            if (db.Users.Where(x => x.Username == Username && x.password == password).Count() > 0)

                return true;
            else
                return false;

        }

        public ActionResult SignOut()
        {

            Session["USER_SESSION"] = null;
            Session["SESSION_GROUP"] = null;


            if (Request.Cookies["Username"] != null && Request.Cookies["password"] != null)
            {
                HttpCookie us = Request.Cookies["Username"];
                HttpCookie pass = Request.Cookies["password"];

                pass.Expires = DateTime.Now.AddDays(-1);
                us.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(us);
                Response.Cookies.Add(pass);
            }

            return Redirect("/Admin/Login");
        }
    }
}