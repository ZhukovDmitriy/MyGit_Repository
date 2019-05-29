using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompAccessory.WedUI.Models
{
    public class LoginViewModel
    {
        // Атрибут анотации данных Required - указывает, что значение поля данных является обязательным
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        // Атрибут DataType позволяет указать, каким образом значение должно представляться  и редактироваться.
        // MVC Framework визуализирует редактор для свойства Password как HTML-элемент для ввода пароля,
        // который обеспечивает маскирование символов пароля при вводе.
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}