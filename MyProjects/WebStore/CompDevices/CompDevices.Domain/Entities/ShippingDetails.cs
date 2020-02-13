using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CompDevices.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Пожалуйста введите ваше Ф.И.О!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите номер вашего телефона!")]
        public string Phone { get; set; }
    }
}
