using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Models;

namespace Messenger.Infrastructure.Abstract
{
    // Интерфейс содержащий свойства и методы для работы с пользователями системы
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Role> Roles { get; }
    }
}
