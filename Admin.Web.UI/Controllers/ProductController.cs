using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using Admin.BLL.Helpers;
using Admin.BLL.Repository;
using Admin.BLL.Services;
using Admin.Models.Entities;
using Admin.Models.Models;
using Admin.Models.ViewModels;

namespace Admin.Web.UI.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            ViewBag.ProductList = GetProductSelectList();
            ViewBag.CategoryList = GetCategorySelectList();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProductList = GetProductSelectList();
                ViewBag.CategoryList = GetCategorySelectList();
                return View(model);
            }

            try
            {
                if (model.Product.SupProductId.ToString().Replace("0", "").Replace("-", "").Length == 0)
                    model.Product.SupProductId = null;

                model.Product.LastPriceUpdateDate = DateTime.Now;
                Product product = new Product()
                {
                    Category = model.Product.Category,
                    Description = model.Product.Description,
                    ProductName = model.Product.ProductName,
                    SalesPrice = model.Product.SalesPrice,
                    BuyPrice = model.Product.BuyPrice,
                    Id = model.Product.Id,
                    ImagePath = model.Product.ImagePath,
                    Barcode = model.Product.Barcode,
                    CreatedDate = model.Product.CreatedDate,
                    Invoices = model.Product.Invoices,
                    LastPriceUpdateDate = model.Product.LastPriceUpdateDate,
                    ProductType = model.Product.ProductType,
                    Products = model.Product.Products,
                    Quantity = model.Product.Quantity,
                    SupProduct = model.Product.SupProduct,
                    SupProductId = model.Product.SupProductId,
                    UnitsInStock = model.Product.UnitsInStock,
                    UpdatedDate = model.Product.UpdatedDate
                };
                product.CategoryId = model.Product.CategoryId;
                if (model.PostedFile != null &&
                    model.PostedFile.ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    model.PostedFile.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();
                    model.Image = data;


                    var file = model.PostedFile;
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extName = Path.GetExtension(file.FileName);
                    fileName = StringHelpers.UrlFormatConverter(fileName);
                    fileName += StringHelpers.GetCode();
                    var klasoryolu = Server.MapPath("~/Upload/");
                    var dosyayolu = Server.MapPath("~/Upload/") + fileName + extName;

                    if (!Directory.Exists(klasoryolu))
                        Directory.CreateDirectory(klasoryolu);
                    file.SaveAs(dosyayolu);

                    WebImage img = new WebImage(dosyayolu);
                    img.Resize(250, 250, false);
                    img.AddTextWatermark("Wissen");
                    img.Save(dosyayolu);
                    product.ImagePath = "/Upload/" + fileName + extName;
                }
                await new ProductRepo().InsertAsync(product);
                TempData["Message"] = $"{model.Product.ProductName} isimli ürün başarıyla eklenmiştir";
                return RedirectToAction("Add");
            }
            catch (DbEntityValidationException ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu: {EntityHelpers.ValidationMessage(ex)}",
                    ActionName = "Add",
                    ControllerName = "Product",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu: {ex.Message}",
                    ActionName = "Add",
                    ControllerName = "Product",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult List()
        {
            try
            {
                List<Product> model = new ProductRepo().GetAll();
                if (model != null)
                    return View(model);
            }
            catch (Exception ex)
            {
                TempData["Model"] = new ErrorViewModel()
                {
                    Text = $"Bir hata oluştu: {ex.Message}",
                    ActionName = "List",
                    ControllerName = "Product",
                    ErrorCode = 500
                };
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("List", "Product");
        }

    }
}