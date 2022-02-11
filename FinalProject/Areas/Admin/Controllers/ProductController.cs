using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using System.IO;

namespace FinalProject.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        public ActionResult Index()
        {
            List<SanPham> lst = db.SanPhams.ToList(); ;

            return View(lst);
        }
        public ActionResult Add()
        {
            SetViewbag1();
            SetViewbag2();
            return View();
        }
        [HttpPost]
        public ActionResult Add(SanPham sp, HttpPostedFileBase uploadhinh)
        {


            db.SanPhams.Add(sp);

            db.SaveChanges();

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                string id = db.SanPhams.ToList().Last().ProductID.ToString();

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "sp" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/images/sanpham"), _FileName);
                uploadhinh.SaveAs(_path);

                SanPham usp = db.SanPhams.FirstOrDefault(x => x.ProductID == id);
                usp.image = _FileName;
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.ProductID == id);
            SetViewbag1(sp.LoaiSP);
            SetViewbag2(sp.ThuongHieu);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Edit(SanPham sp, HttpPostedFileBase uploadhinh)
        {
            SanPham suasp = db.SanPhams.FirstOrDefault(x => x.ProductID == sp.ProductID);
            suasp.TenSP = sp.TenSP;
            suasp.LoaiSP = sp.LoaiSP;
            suasp.ThuongHieu = sp.ThuongHieu;
            suasp.GiaNhap = sp.GiaNhap;
            suasp.GiaBan = sp.GiaBan;
            suasp.SoLuong = sp.SoLuong;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                string id = sp.ProductID;

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "sp" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/images/sanpham"), _FileName);
                uploadhinh.SaveAs(_path);
                suasp.image = _FileName;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.ProductID == id);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void SetViewbag1(String selectedid = null)
        {
            ViewBag.LoaiSP = new SelectList(db.LoaiSanPhams.ToList(), "MaLSP", "TenLSP", selectedid);
        }
        public void SetViewbag2(String selectedid = null)
        {
            ViewBag.ThuongHieu = new SelectList(db.NhaCungCaps.ToList(), "MaNCC", "TenNCC", selectedid);
        }
    }
}