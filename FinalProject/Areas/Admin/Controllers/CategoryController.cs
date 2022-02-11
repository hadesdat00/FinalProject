using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<LoaiSanPham> lst = db.LoaiSanPhams.ToList();
            return View(lst);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(LoaiSanPham lsp)
        {
            db.LoaiSanPhams.Add(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            LoaiSanPham lsp = db.LoaiSanPhams.FirstOrDefault(x => x.MaLSP == id);
            return View(lsp);
        }

        [HttpPost]
        public ActionResult Edit(LoaiSanPham lsp)
        {
            LoaiSanPham sualsp = db.LoaiSanPhams.FirstOrDefault(x => x.MaLSP == lsp.MaLSP);
            sualsp.TenLSP = lsp.TenLSP;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            LoaiSanPham lsp = db.LoaiSanPhams.FirstOrDefault(x => x.MaLSP == id);
            db.LoaiSanPhams.Remove(lsp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}