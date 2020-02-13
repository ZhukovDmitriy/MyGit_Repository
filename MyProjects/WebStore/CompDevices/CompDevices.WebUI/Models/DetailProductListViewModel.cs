using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompDevices.Domain.Entities;

namespace CompDevices.WebUI.Models
{
    public class DetailProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductAttributesViewModel> AttributesViewModels { get; set; }
        public int ProductID { get; set; }
    }
}