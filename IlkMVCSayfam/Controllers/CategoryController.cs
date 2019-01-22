using System;
using IlkMVCSayfam.Models;
using System.Linq;
using System.Web.Mvc;

namespace IlkMVCSayfam.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var data = new NorthwindSabahEntities()
                .Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(data);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var data = new NorthwindSabahEntities().Categories.Find(id.Value);
            if (data == null) RedirectToAction("Index");

            return View(data);
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            try
            {
                var db = new NorthwindSabahEntities();
                db.Categories.Add(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            var db = new NorthwindSabahEntities();
            try
            {
                var category = db.Categories.Find(id.GetValueOrDefault());
                if (category == null) return RedirectToAction("Index");

                db.Categories.Remove(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Category");

            try
            {
                var data = new NorthwindSabahEntities().Categories.Find(id.Value);
                if (data == null)
                    return RedirectToAction("Index", "Category");

                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Category");
            }
        }

        [HttpPost]
        public ActionResult Update(Category model)
        {
            try
            {
                var db = new NorthwindSabahEntities();
                var data = db.Categories.Find(model.CategoryID);

                if (data == null)
                    return RedirectToAction("Index");

                data.CategoryName = model.CategoryName;
                data.Description = model.Description;
                db.SaveChanges();
                ViewBag.Message = "<span class='text text-success'>Update Successfully</span>";
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"<span class='text text-danger'>Update Error {ex.Message}</span>";
                return View(model);
            }
        }

        public JsonResult Categories()
        {
            var categoriler = new NorthwindSabahEntities().Categories.Select(x => new
            {
                x.CategoryName,
                x.CategoryID,
                x.Description,
                ProductCount = x.Products.Count
            }).ToList();

            return Json(categoriler, JsonRequestBehavior.AllowGet);
        }
    }
}