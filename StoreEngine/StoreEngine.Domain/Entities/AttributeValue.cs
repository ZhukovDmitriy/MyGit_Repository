using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreEngine.Domain.Entities
{
    public class AttributeValue
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public int AttributeID { get; set; }
        public Attribute Attribute { get; set; }
        public string Value { get; set; }
    }
}
