using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/Customer
        public ActionResult Index()
        {
            List<KhachHang> lst = db.KhachHangs.ToList();
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(KhachHang khh)
        {
            db.KhachHangs.Add(khh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            KhachHang khh = db.KhachHangs.FirstOrDefault(x => x.CustomerID == id);
            return View(khh);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang khh)
        {
            KhachHang suakhh = db.KhachHangs.FirstOrDefault(x => x.CustomerID == khh.CustomerID);
            suakhh.ShipName = khh.ShipName;
            suakhh.ShipMobile = khh.ShipMobile;
            suakhh.ShipAddress = khh.ShipAddress;
            suakhh.ShipEmail = khh.ShipEmail;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            KhachHang khh = db.KhachHangs.FirstOrDefault(x => x.CustomerID == id);
            db.KhachHangs.Remove(khh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}