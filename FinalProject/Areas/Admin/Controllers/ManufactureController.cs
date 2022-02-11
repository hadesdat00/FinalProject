using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class ManufactureController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/Manufacture
        public ActionResult Index()
        {
            List<NhaCungCap> lst = db.NhaCungCaps.ToList();
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NhaCungCap ncc)
        {
            db.NhaCungCaps.Add(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(x => x.MaNCC == id);
            return View(ncc);
        }

        [HttpPost]
        public ActionResult Edit(NhaCungCap ncc)
        {
            NhaCungCap suancc = db.NhaCungCaps.FirstOrDefault(x => x.MaNCC == ncc.MaNCC);
            suancc.TenNCC = ncc.TenNCC;
            suancc.SoDienThoai = ncc.SoDienThoai;
            suancc.DiaChi = ncc.DiaChi;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            NhaCungCap ncc = db.NhaCungCaps.FirstOrDefault(x => x.MaNCC == id);
            db.NhaCungCaps.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}