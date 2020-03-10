using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    // Атрибуты проверки достоверности

namespace CompAccessory.Domain.Entites
{
    public class ShippingDetails
    {
        // Required - указывает, что значение поля данных является обязательным
        [Required(ErrorMessage = "Пожалуйста введите ваше Ф.И.О.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите ваш Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите номер вашего телефона")]
        public string Line { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите название города")]
        public string City { get; set; }
    }
}
