using AjaxIslemleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxIslemleri.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllOrderData()
        {
            var db = new NorthwindEntities();
            var orderdata = db.Order_Details
                .Join(db.Products,
                od => od.ProductID,
                p => p.ProductID,
                (od, p) => new { od, p })
                .Join(db.Categories,
                gg => gg.p.ProductID,
                c => c.CategoryID,
                (gg, c) => new { gg, c })
                .GroupBy(x => x.c.CategoryName)
                .Select(x => new
                {
                    Category = x.Key,
                    Total = x.Sum(y => y.gg.od.Quantity)
                }).ToArray();

            return Json(orderdata, JsonRequestBehavior.AllowGet);
        }
    }
}