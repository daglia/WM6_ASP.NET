using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Models.Abstracts;
using Admin.Models.Enums;

namespace Admin.Models.Entities
{
    [Table("Orders")]
    public class Order : BaseEntity<long>
    {
        [DisplayName("Sipariş Tipi")]
        public OrderTypes OrderType { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    }
}
