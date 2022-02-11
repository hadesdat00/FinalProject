using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.common;
using PagedList;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;

            var dsproducts = (from l in db.SanPhams
                              select l).OrderBy(x => x.ProductID);

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(dsproducts.ToPagedList(pageNumber, pageSize)); ;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult chitietblog()
        {
            return View();
        }
    }
}