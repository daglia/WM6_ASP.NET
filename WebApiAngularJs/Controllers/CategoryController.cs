﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAngularJs.Models;

namespace WebApiAngularJs.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    data = db.Categories.Select(x => new CategoryViewModel()
                    {
                        CategoryID = x.CategoryID,
                        CategoryName = x.CategoryName,
                        Description = x.Description
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu {ex.Message}");
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id = 0)
        {
            try
            {
                var cat = db.Categories.Find(id);
                if (cat == null)
                {
                    return NotFound();
                }

                var data = db.Categories.Select(x => new CategoryViewModel()
                {
                    CategoryID = cat.CategoryID,
                    CategoryName = cat.CategoryName,
                    Description = cat.Description
                });
                return Ok(new
                {
                    success = true,
                    data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] CategoryViewModel model)
        {
            try
            {
                db.Categories.Add(new Category()
                {
                    CategoryName = model.CategoryName,
                    Description = model.Description
                });
                db.SaveChanges();

                return Ok(new
                {
                    success = true,
                    message = "Kategori ekleme işlemi başarılı."
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Bir hata oluştu: {ex.Message}");
            }
        }
    }

    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}