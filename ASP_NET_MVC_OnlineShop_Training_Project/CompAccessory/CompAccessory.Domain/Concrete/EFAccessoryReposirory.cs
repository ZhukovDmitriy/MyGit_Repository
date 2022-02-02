using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompAccessory.Domain.Abstract;
using CompAccessory.Domain.Entites;

// ADO.NET Entity Framework (EF) - объектно-ориентированная технология доступа к данным.
// Entity Framework представляет собой более высокий уровень абстракции, 
// который позволяет абстрагироваться от самой базы данных и работать с данными независимо от типа хранилища. 
// Если на физическом уровне мы оперируем таблицами, индексами, первичными и внешними ключами, 
// то на концептуальном уровне, который нам предлагает Entity Framework, мы уже работает с объектами.

namespace CompAccessory.Domain.Concrete
{
    // Это класс хранилища. Он реализует интерфейс IAccessoryRepository 
    // и использует экземпляр EFDbContext для извлечения данных из базы посредством Entity Framework.
    public class EFAccessoryReposirory : IAccessoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Accessory> Accessories { get { return context.Accessories; } }

        // Реализация метода SaveAccessory добавляет товар в хранилище, если значение AccessoryID равно 0;
        // в противном случае применяются изменения к существующей записи в базе данных, путем извлечения
        // из хранилища объекта Accessory с тем же самым значением AccessoryID и обновлением всех его свойств
        // согласно объекту, переданному в качестве параметра
        public void SaveAccessory(Accessory accessory)
        {
            if (accessory.AccessoryID == 0)
            {
                context.Accessories.Add(accessory);
            }
            else
            {
                Accessory dbEntry = context.Accessories.Find(accessory.AccessoryID);
                if (dbEntry != null)
                {
                    // Обеспечиваем сохранения в базе данных значений присвоенным свойствам
                    dbEntry.Name = accessory.Name;
                    dbEntry.Description = accessory.Description;
                    dbEntry.Price = accessory.Price;
                    dbEntry.Category = accessory.Category;
                    dbEntry.ImageData = accessory.ImageData;
                    dbEntry.ImageMimeType = accessory.ImageMimeType;
                }
            }

            context.SaveChanges();
        }

        public Accessory DeleteAccessory(int accessoryID)
        {
            Accessory dbEntry = context.Accessories.Find(accessoryID);
            if (dbEntry != null)
            {
                context.Accessories.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
