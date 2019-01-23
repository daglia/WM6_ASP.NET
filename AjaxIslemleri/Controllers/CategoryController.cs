using AjaxIslemleri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxIslemleri.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Search(string s)
        {
            var key = s.ToLower();
            if (key.Length <= 2)
                return Json(new ResponseData()
                {
                    message = "Aramak için 2 karakterden fazlasını girin",
                    success = false
                },JsonRequestBehavior.AllowGet);

            try
            {
                var db = new NorthwindEntities();
                db.Configuration.LazyLoadingEnabled = false;
                var data = db.Categories.Where(x => x.CategoryName.ToLower().Contains(key) || x.Description.Contains(key)).ToList();

                return Json(new ResponseData()
                {
                    message = $"{data.Count} adet kayıt bulundu.",
                    success = true,
                    data = data
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseData()
                {
                    message = $"Bir hata oluştu!\n{ex.Message}",
                    success = false,
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }

    
}