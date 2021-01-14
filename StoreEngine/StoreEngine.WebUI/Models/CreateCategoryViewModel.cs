using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreEngine.Domain.Entities;

namespace StoreEngine.WebUI.Models
{
    public class CreateCategoryViewModel
    {
        public Category Category { get; set; }
        public List<Domain.Entities.Attribute> Attributes { get; set; }
    }
}