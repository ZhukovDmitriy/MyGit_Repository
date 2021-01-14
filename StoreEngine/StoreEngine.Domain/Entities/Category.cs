using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StoreEngine.Domain.Entities
{
    public class Category
    {
        [HiddenInput(DisplayValue = false)]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a category name")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }        
    }
}