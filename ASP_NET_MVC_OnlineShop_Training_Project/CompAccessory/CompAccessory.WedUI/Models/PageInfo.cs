using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompAccessory.WedUI.Models
{
    // Класс модели представления - не является частью нашей модели предметной области
    // Это всего лишь удобный класс для передачи даных между контроллером и представлением
    public class PageInfo
    {
        public int TotalItems { get; set; }         // Общее количество товаров 
        public int ItemsPerPages { get; set; }      // Количество элементов на странице
        public int CurrentPage { get; set; }        // Текущая страница

        // Количество доступных страниц 
        public int TotalPages { get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPages); } }
        // [Пример] 12 товаров / 4 элемента на странице = 3 страницы 
    }
}