using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxIslemleri.Models
{
    public class ResponseData
    {
        public string message { get; set; }
        public bool success { get; set; }
        public object data { get; set; }
        public DateTime responseTime { get; set; } = DateTime.Now;
        public string responseTimeU { get; set; } = $"{DateTime.Now:O}";
    }
}