using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/Order
        public ActionResult Index()
        {
            List<Order> lst = db.Orders.ToList();
            return View(lst);
        }

        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(Order od)
        {
            db.Orders.Add(od);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            Order od = db.Orders.FirstOrDefault(x => x.OrderID == id);

            return View(od);
        }

        [HttpPost]

        public ActionResult Edit(Order od)
        {
            Order suaod = db.Orders.FirstOrDefault(x => x.OrderID == od.OrderID);
            suaod.CreatedDate = od.CreatedDate;
            suaod.ShipName = od.ShipName;
            suaod.ShipMobile = od.ShipMobile;
            suaod.ShipAddress = od.ShipAddress;
            suaod.ShipEmail = od.ShipEmail;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(long id)
        {
            Order od = db.Orders.FirstOrDefault(x => x.OrderID == id);
            db.Orders.Remove(od);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}