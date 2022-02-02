using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompAccessory.Domain.Entites;

namespace CompAccessory.WedUI.Models
{
    // Нужно предоставить представлению экземпляр класса модели представаления PageInfo 
    // Необходимо поместить все данные, которые требуется передать из контроллера в представление, в один класс модели представления
    public class AccessoriesListViewModel
    {
        // Объект IEnumerable представляет набор данных в памяти и может перемещаться по этим данным только вперед
        public IEnumerable<Accessory> Accessories { get; set; }
        public PageInfo PageInfo { get; set; }                      // Экземпляр класса модели представления 
        public string CurrentCategory { get; set; }                 // Свойство - текущая категория 
    }
}