﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.DAL;
using Admin.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Admin.BLL.Identity
{
    public class MembershipTools
    {
        private static MyContext _db;

        public static UserStore<User> NewUserStore() => new UserStore<User>(_db ?? new MyContext());
        public static UserManager<User> NewUserManager() => new UserManager<User>(NewUserStore());

        public static RoleStore<Role> NewRoleStore() => new RoleStore<Role>(_db ?? new MyContext());
        public static RoleManager<Role> NewRoleManager() => new RoleManager<Role>(NewRoleStore());
    }
}
