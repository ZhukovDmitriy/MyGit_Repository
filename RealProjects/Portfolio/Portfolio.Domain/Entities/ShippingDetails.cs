using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Пожалуйста введите ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста укажите номер вашего телефона")]
        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Пожалуйста опишите необходимую услугу")]
        public string Message { get; set; }
    }
}
