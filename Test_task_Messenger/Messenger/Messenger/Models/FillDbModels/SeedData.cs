using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Messenger.Infrastructure.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Models.SeedModels
{
    public static class SeedData
    {
        // Метод получает объект ApplicationDbContext через интерфейс IApplicationBuilder
        // и вызывает метод Database.Migrate() чтобы гарантировать применение миграции
        // Далее проверяется количество объектов конкретного класса в БД.
        // Если объекты в базе отсутствуют, то БД заполняется коллекцией объектов 
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                   new Role
                   {
                       RoleName = "Admin"
                   },
                   new Role
                   {
                       RoleName = "User"
                   });

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                   new User
                   {
                       FirstName = "Жуков",
                       LastName = "Дмитрий",
                       RoleID = 1,
                       Login = "Admin",
                       Password = "Admin123"
                   },
                   new User
                   {
                       FirstName = "Иванов",
                       LastName = "Иван",
                       RoleID = 2,
                       Login = "Ivanov",
                       Password = "Ivanov123"
                   },
                   new User
                   {
                       FirstName = "Смирнов",
                       LastName = "Владимир",
                       RoleID = 2,
                       Login = "Smirnov",
                       Password = "Smirnov123"
                   });

                context.SaveChanges();
            }
        }
    }
}
