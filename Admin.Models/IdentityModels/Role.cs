using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Admin.Models.IdentityModels
{
    public class Role : IdentityRole
    {
        public Role()
        {
            
        }

        public Role(string description)
        {
            Description = description;
        }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
