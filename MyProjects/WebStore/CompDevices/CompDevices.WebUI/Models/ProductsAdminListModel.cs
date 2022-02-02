using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompDevices.Domain.Entities;

namespace CompDevices.WebUI.Models
{
    public class ProductsAdminListModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string SelectedCategory { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}