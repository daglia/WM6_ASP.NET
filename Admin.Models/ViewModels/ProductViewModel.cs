using Admin.Models.Entities;
using System.Web;

namespace Admin.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public string ImagePath { get; set; }
        public byte[] Image { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }
    }
}