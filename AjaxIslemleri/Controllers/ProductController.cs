using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxIslemleri.Models;
using AjaxIslemleri.Models.ViewModels;

namespace AjaxIslemleri.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            try
            {
                var db = new NorthwindEntities();
                var data = db.Categories.Select(x => new CategoryViewModel()
                {
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    CategoryID = x.CategoryID,
                    ProductCount = x.Products.Count
                }).ToList();
                return Json(new ResponseData()
                {
                    success = true,
                    data = data
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseData()
                {
                    success = false,
                    message = $"Bir hata oluştu!\n{ex.Message}"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            try
            {
                var db = new NorthwindEntities();
                var data = db.Products.OrderBy(x => x.ProductName).ToList()
                    .Select(x=> new ProductViewModel()
                    {
                        CategoryName = x.Category?.CategoryName,
                        ProductName = x.ProductName,
                        ProductID = x.ProductID,
                        CategoryID = x.CategoryID,
                        AddedDate = x.AddedDate,
                        AddedDateFormatted = $"{x.AddedDate:g}",
                        Discontinued = x.Discontinued,
                        UnitPrice = x.UnitPrice,
                        UnitPriceFormatted = $"{x.UnitPrice:c2}",
                        SupplierID = x.SupplierID,
                        UnitsOnOrder = x.UnitsOnOrder,
                        UnitsInStock = x.UnitsInStock,
                        SupplierName = x.Supplier?.CompanyName,
                        ReorderLevel = x.ReorderLevel,
                        QuantityPerUnit = x.QuantityPerUnit
                    });
                return Json(new ResponseData()
                {
                    success = true,
                    data = data
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new ResponseData()
                {
                    success = false,
                    message = $"Bir hata oluştu!\n{ex.Message}"
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}