using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject  .Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class WarehouseController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/Warehouse
        public ActionResult Index()
        {
            List<KhoHang> lst = db.KhoHangs.ToList();
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(KhoHang kh)
        {
            db.KhoHangs.Add(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            KhoHang kh = db.KhoHangs.FirstOrDefault(x => x.MaKho == id);
            return View(kh);
        }

        [HttpPost]
        public ActionResult Edit(KhoHang kh)
        {
            KhoHang suakh = db.KhoHangs.FirstOrDefault(x => x.MaKho == kh.MaKho);
            suakh.TenKho = kh.TenKho;
            suakh.SoDienThoai = kh.SoDienThoai;
            suakh.DiaChi = kh.DiaChi;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            KhoHang kh = db.KhoHangs.FirstOrDefault(x => x.MaKho == id);
            db.KhoHangs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}