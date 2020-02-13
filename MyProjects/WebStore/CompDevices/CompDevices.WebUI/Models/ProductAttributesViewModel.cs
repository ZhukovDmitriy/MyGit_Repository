using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompDevices.WebUI.Models
{
    public class ProductAttributesViewModel
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public bool SelectiveAttribute { get; set; }
        public string AttributeName { get; set; }
        public string Value { get; set; }
    }
}