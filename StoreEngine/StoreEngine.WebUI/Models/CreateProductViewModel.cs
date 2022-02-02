using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreEngine.Domain.Entities;

namespace StoreEngine.WebUI.Models
{
    public class CreateProductViewModel
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Domain.Entities.Attribute> Attributes { get; set; }
        public IEnumerable<AttributeValue> AttributeValues { get; set; }
        public List<Image> Images { get; set; }
    }
}