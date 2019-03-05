using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DevexOdata.Models;

namespace DevexOdata.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return Ok(new
            {
                success = true,
                data = db.Customers.ToList()
            });
        }
    }
}
