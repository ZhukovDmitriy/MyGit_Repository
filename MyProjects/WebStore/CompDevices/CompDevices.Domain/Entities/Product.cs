using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CompDevices.Domain.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите бренд товара!")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите модель товара!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Пожалуйста заполните краткое описание товара!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Пожалуйста заполните полное описание товара!")]
        [DataType(DataType.MultilineText)]
        public string TotalDescription { set; get; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста введите положительну цену на товар!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите категорию товара!")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
