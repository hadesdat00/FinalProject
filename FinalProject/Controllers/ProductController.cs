using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using PagedList;
using PagedList.Mvc;
using FinalProject.common;


namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Product
        //public ActionResult Category()
        //{
        //    List<SanPham> lst = db.SanPhams.ToList();
        //    return View(lst);
        //}

        public ActionResult Category(int? page)
        {
            if (page == null) page = 1;

            var dsproducts = (from l in db.SanPhams
                              select l).OrderBy(x => x.ProductID);

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(dsproducts.ToPagedList(pageNumber, pageSize)); ;
        }

        public ActionResult ProductDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);

        }

        public ActionResult SubCategory(string id)
        {
            var lstproduct = db.SanPhams.Where(x => x.LoaiSP == id).ToList();
            return View(lstproduct);
        }

        [ChildActionOnly]
        public ActionResult CategoryPartial()
        {
            return PartialView("CategoryPartial", db.LoaiSanPhams.ToList());
        }

        public ActionResult Brand(string id)
        {
            var listproduct = db.SanPhams.Where(x => x.ThuongHieu == id).ToList();
            return View(listproduct);
        }

        [ChildActionOnly]
        public ActionResult CategoryPartial2()
        {
            return PartialView("CategoryPartial2", db.NhaCungCaps.ToList());
        }

        [ChildActionOnly]
        public ActionResult NavbarPartial1()
        {
            return PartialView("NavbarPartial1", db.LoaiSanPhams.ToList());
        }

        [ChildActionOnly]
        public ActionResult NavbarPartial2()
        {
            return PartialView("NavbarPartial2", db.NhaCungCaps.ToList());
        }

        public ActionResult FooterPartial()
        {
            return PartialView("FooterPartial", db.NhaCungCaps.ToList());
        }
    }
}