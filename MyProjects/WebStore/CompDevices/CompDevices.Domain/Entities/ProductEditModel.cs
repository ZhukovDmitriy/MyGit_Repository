using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompDevices.Domain.Entities
{
    public class ProductEditModel
    {
        public Product Products { get; set; }
        public List<ProductAttribute> ProductAttributes { get; set; }
        public List<AttributeValue> AttributeValues { get; set; }
    }
}
