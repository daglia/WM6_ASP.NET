using IlkMVCSayfam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IlkMVCSayfam.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            var data = new NorthwindSabahEntities()
                .Employees
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
            return View(data);
        }

        public ActionResult Detail(int? id) {
            if (id == null)
                return RedirectToAction("Index");

            var data = new NorthwindSabahEntities()
                .Employees
                .Find(id.Value);

            if(data == null)
                return RedirectToAction("Index");

            return View(data);
        }

        public ActionResult Delete(int? id)
        {
            var db = new NorthwindSabahEntities();
            try
            {
                var employee = db.Employees.Find(id.GetValueOrDefault());
                if (employee == null) return RedirectToAction("Index");

                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            try
            {
                var db = new NorthwindSabahEntities();
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            try
            {
                var data = new NorthwindSabahEntities().Employees.Find(id.Value);
                if (data == null)
                    return RedirectToAction("Index");

                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            try
            {
                var db = new NorthwindSabahEntities();
                var data = db.Employees.Find(employee.EmployeeID);

                if (data == null)
                    return RedirectToAction("Index");

                data.FirstName = employee.FirstName;
                data.LastName = employee.LastName;
                data.BirthDate = employee.BirthDate;
                data.HomePhone = employee.HomePhone;
                data.Address = employee.Address;
                db.SaveChanges();
                ViewBag.Message = "<span class='text text-success'>Başarıyla güncellendi.</span>";
                return View(data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"<span class='text text-danger'>Update Error {ex.Message}</span>";
                return View(employee);
            }
        }
    }
}