using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Kuzey.BLL.Repository;
using Kuzey.Models.Entities;
using Kuzey.Models.ViewModels;
using Kuzey.Web.App_Code;

namespace Kuzey.Web.Controllers
{
    [ExceptionHandlerFilter]
    [RoutePrefix("Urun")]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var data = new ProductRepo().GetAll().Select(x => Mapper.Map<ProductViewModel>(x)).ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel model)
        {
            new ProductRepo().Insert(Mapper.Map<ProductViewModel, Product>(model));
            return View();
        }

        [HttpGet]
        [Route("~/{kategoriadi}/{urunadi}-{id?}/ayrinti")]
        public ActionResult Detail(string kategoriadi, string urunadi, int id = 0)
        {
            var model = new ProductRepo().GetById(id);
            var data = Mapper.Map<ProductViewModel>(model);
            return View(data);
        }
    }
}