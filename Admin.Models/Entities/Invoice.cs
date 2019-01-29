﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Models.Abstracts;

namespace Admin.Models.Entities
{
    [Table("Invoices")]
    public class Invoice : BaseEntity2<long,Guid>
    {
        [DisplayName("Birim")]
        public decimal Quantity { get; set; }
        [DisplayName("Fiyat")]
        public decimal Price { get; set; }
        [DisplayName("İndirim Oranı")]
        public decimal Discount { get; set; }

        [ForeignKey("Id")]
        public virtual Order Order { get; set; }

        [ForeignKey("Id2")]
        public virtual Product Product { get; set; }
    }
}
