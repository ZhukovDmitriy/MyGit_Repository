using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreEngine.Domain.Entities;

namespace StoreEngine.WebUI.Models
{
    public class AdminIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}