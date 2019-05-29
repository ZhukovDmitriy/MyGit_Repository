using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CompAccessory.Domain.Entites
{
    public class Accessory
    {
        // Используем "метаданные модели", позволяющие применять к свойствам нового класса модели 
        // атрибуты, оказывая влияние на вывод метода Html.EditorForModel

        // Атрибут HiddenInput сообщает инфраструктуре MVC Framework о том, что свойство 
        // должно визуализироваться в виде скрытого элемента формы (System.Web.Mvc)
        [HiddenInput(DisplayValue = false)]
        public int AccessoryID { get; set; }

        // Свойство Name атрибута Display содержит строку, которая будет отображаться вместо имени свойства
        [Required(ErrorMessage = "Пожалуйста введите название товара")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        // Атрибут DataType позволяет указать, каким образом значение должно представляться 
        // и редактироваться. В этом случае был выбран MultilineText (System.ComponentModel.DataAnnotations)
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Пожалуйста заполните описание к товару")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]  // Range - задает ограничения числового диапозона. MaxValue - представляет наибольшее возможное значение.
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста введите положительное значение")]
        [Display(Name = "Цена(грн)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Пожалуйста уточните категорию товара")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        // Инфраструктура MVC не визуализирует редакторы для байтовых массивов
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
