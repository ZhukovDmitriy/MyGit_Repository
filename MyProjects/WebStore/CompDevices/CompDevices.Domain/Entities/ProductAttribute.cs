using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CompDevices.Domain.Entities
{
   public class ProductAttribute
    {
        [Key]
        public int AttributeID { get; set; }
        public bool SelectiveAttribute { get; set; }
        public bool FilterAttribute { get; set; }
        public string Category { get; set; }
        public string AttributeName { get; set; }
    }
}
