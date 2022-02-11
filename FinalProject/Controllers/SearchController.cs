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
    public class SearchController : Controller
    {
        FinalProjectDBEntities db = new FinalProjectDBEntities();
        // GET: Search
        public ActionResult SearchResult(string keyword)
        {
            var lstsp = db.SanPhams.Where(x => x.TenSP.Contains(keyword));
            return View(lstsp.OrderBy(x => x.TenSP));
        }
    }
}