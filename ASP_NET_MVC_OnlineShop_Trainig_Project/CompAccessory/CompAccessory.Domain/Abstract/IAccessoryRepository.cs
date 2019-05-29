using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompAccessory.Domain.Entites;

namespace CompAccessory.Domain.Abstract
{
    public interface IAccessoryRepository
    {
        // Интерфейс IQueryable располагается в пространстве имен System.Linq
        // Объект IQueryable предоставляет удаленный доступ к базе данных
        // и позволяет перемещаться по данным как в прямом порядке от начала до конца, так и в обратном порядке
        IQueryable<Accessory> Accessories { get; }

        void SaveAccessory(Accessory accessory);

        Accessory DeleteAccessory(int accessoryID);
    }
}
