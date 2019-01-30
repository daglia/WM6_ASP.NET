using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.BLL.Helpers;
using Admin.BLL.Repository;
using Admin.Models.Entities;
using Admin.Models.ViewModels;

namespace Admin.Web.UI.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.CategoryList = GetCategorySelectList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // ÇOK ÖNEMLİ
        public ActionResult Add(Category model)
        {
            try
            {
                model.TaxRate /= 100;
                if (model.SupCategoryId == 0) model.SupCategoryId = null;
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("TaxRate","Geçersiz bir KDV oranı.");
                    model.SupCategoryId = model.SupCategoryId ?? 0;
                    ViewBag.CategoryList = GetCategorySelectList();
                    return View(model);
                } // Data annotation yapılan değişkenlerin doğrulamasını yapar.

                if (model.SupCategoryId > 0)
                {
                    model.TaxRate = new CategoryRepo().GetById(model.SupCategoryId).TaxRate;
                }

                new CategoryRepo().Insert(model);

                TempData["Message"] = $"{model.CategoryName} isimli kategori başarıyla eklendi.";

                return RedirectToAction("Add");
            }

            catch (DbEntityValidationException ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu:\n{EntityHelpers.ValidationMessage(ex)}",
                    ActionName = "Add",
                    ControllerName = "Category",
                    ErrorCode = 500
                };
                return RedirectToAction("Error","Home");
            }

            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu:\n{ex.Message}",
                    ActionName = "Add",
                    ControllerName = "Category",
                    ErrorCode = 500
                };
                return RedirectToAction("Error","Home");
            }
        }
    }
}