﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Admin.BLL.Identity;
using Admin.Models.IdentityModels;
using Microsoft.AspNet.Identity;

namespace Admin.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var roller = new string[] {"Admin", "User"};

            var roleManager = MembershipTools.NewRoleManager();
            foreach (var rol in roller)
            {
                if (roleManager.RoleExists(rol))
                    roleManager.Create(new Role()
                    {
                        Name = rol
                    });
            }
        }
    }
}
