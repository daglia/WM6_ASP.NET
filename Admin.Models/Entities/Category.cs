using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin.Models.Abstracts;

namespace Admin.Models.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity<int>
    {
        [StringLength(100,ErrorMessage = "Kategori adı en az 3, en fazla 100 karakter içerebilir.",MinimumLength = 3)]
        [DisplayName("Kategori Adı")]
        [Required]
        public string CategoryName { get; set; }

        [DisplayName("KDV Oranı")]
        [Range(0, 99)]
        public decimal TaxRate { get; set; }

        [DisplayName("Üst Kategori")]
        public int? SupCategoryId { get; set; }

        [ForeignKey("SupCategoryId")]
        public virtual Category SupCategory { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
