﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.BLL.Helpers
{
    public static class EnumHelpers
    {
        public static string GetDescription<T>(T item)
        {
            var descriptionAttributes = typeof(T)
                .GetMember(typeof(T)
                .GetEnumName(item))[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)[0];
            return ((DescriptionAttribute) descriptionAttributes).Description;
        }
    }
}
