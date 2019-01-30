using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models.Enums
{
    public enum ProductTypes
    {
        [Description("Toptan")]
        Bulk = 10,
        [Description("Perakende")]
        Retail = 100
    }
}
