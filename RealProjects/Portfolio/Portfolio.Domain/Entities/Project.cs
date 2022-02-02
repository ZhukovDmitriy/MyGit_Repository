using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Portfolio.Domain.Entities
{
    public class Project
    {
        [HiddenInput(DisplayValue = false)]
        public int ProjectID { get; set; }
        
        [Display(Name = "Название проекта")]
        [Required(ErrorMessage = "Пожалуйста введите имя проекта")]
        public string Name { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста заполните описание")]
        public string Description { get; set; }
    }
}
