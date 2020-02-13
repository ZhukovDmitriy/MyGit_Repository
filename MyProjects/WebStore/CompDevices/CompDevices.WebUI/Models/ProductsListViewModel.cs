﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompDevices.Domain.Entities;

namespace CompDevices.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<ProductAttributesViewModel> AttributesViewModels { get; set; }
    }
}