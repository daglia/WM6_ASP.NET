//       ^(.,.)^
//         |O|
//         | |
//         |O|                            minik zürafa
//         | |                            sizin için bu
//         |O|____________;               view'ları döndürüyor
//         |  O   O   O  |
//         |O _ O _ O _ O|
//         |_| |_| |_| |_|


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiAngularJs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }
    }
}