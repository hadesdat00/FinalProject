using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class UserGroupController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/UserGroup
        public ActionResult Index()
        {
            List<UserGroup> lst = db.UserGroups.ToList();
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserGroup ug)
        {
            db.UserGroups.Add(ug);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            UserGroup ug = db.UserGroups.FirstOrDefault(x => x.MaGroup == id);
            return View(ug);
        }

        [HttpPost]
        public ActionResult Edit(UserGroup ug)
        {
            UserGroup suaug = db.UserGroups.FirstOrDefault(x => x.MaGroup == ug.MaGroup);
            suaug.TenGroup = ug.TenGroup;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            UserGroup ug = db.UserGroups.FirstOrDefault(x => x.MaGroup == id);
            db.UserGroups.Remove(ug);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}