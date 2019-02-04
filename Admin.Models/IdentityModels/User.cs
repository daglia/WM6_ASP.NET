using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Admin.Models.IdentityModels
{
    public class User : IdentityUser
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(60)]
        [Required]
        public string Surname { get; set; }
    }
}
