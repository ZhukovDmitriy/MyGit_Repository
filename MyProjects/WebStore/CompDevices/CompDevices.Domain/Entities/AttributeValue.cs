using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CompDevices.Domain.Entities
{
   public class AttributeValue
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public bool SelectiveAttribute { get; set; }
        public int AttributeID { get; set; }
        public string Value { get; set; }
    }
}
