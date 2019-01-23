using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxIslemleri.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }
    }
}