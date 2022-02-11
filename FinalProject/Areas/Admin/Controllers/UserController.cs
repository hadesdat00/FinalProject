using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/User
        public ActionResult Index()
        {
            List<User> lst = db.Users.ToList();
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            User user = db.Users.FirstOrDefault(x => x.MaUser == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            User su = db.Users.FirstOrDefault(x => x.MaUser == user.MaUser);
            su.Username = user.Username;
            su.password = user.password;
            su.MaGroup = user.MaGroup;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            User user = db.Users.FirstOrDefault(x => x.MaUser == id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}