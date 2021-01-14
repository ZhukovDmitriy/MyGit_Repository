using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StoreEngine.Domain.Entities
{
    public class Attribute
    {
        [HiddenInput(DisplayValue = false)]
        public int AttributeID { get; set; }

        [Required(ErrorMessage = "Please enter a attribute name")]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CategoryID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SortPosition { get; set; }
    }
}
