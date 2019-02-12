﻿using System.Web;
using System.Web.Mvc;
using Kuzey.Web.App_Code;


namespace Kuzey.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlerFilterAttribute());
        }
    }
}
