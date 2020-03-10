using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompAccessory.Domain.Entites;
using System.Data.Entity;

namespace CompAccessory.Domain.Concrete
{
    // Подход "сначала код" при котором классы модели связываются с существующей базой данных
    // Класс контекст - связывает нашу модель с базой данных.
    public class EFDbContext : DbContext  // DbContext автоматически определяет свойства для каждой таблицы базы данных, с которой необходмо работать
    {
        // Параметр типа результата DbSet<Accessory> - указывает модель, 
        // которую инфраструктура Enitity Framework должна использовать для предоставления строк в этой таблице
        public DbSet<Accessory> Accessories { get; set; }     // Имя свойства Accessories указывает таблицу базы данных 
        // Тип модели <Accessory> используется для представления строк в таблице Accessories базы данных
    }
}
