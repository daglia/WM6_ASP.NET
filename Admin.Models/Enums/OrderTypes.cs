using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models.Enums
{
    public enum OrderTypes
    {
        [Description("Alış")]
        Buying = 10,
        [Description("Satış")]
        Selling = 20
    }
}
