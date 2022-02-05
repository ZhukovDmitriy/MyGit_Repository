using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Infrastructure.Abstract;
using Messenger.Models;

namespace Messenger.Infrastructure.Concrete
{
    // Класс хранилища, реализует интерфейс IUserRepository
    // Использует экземпляр ApplicationDbContext для извлечения данных из БД
    public class EFUserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public EFUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<User> Users => context.Users;
        public IQueryable<Role> Roles => context.Roles;
    }
}
