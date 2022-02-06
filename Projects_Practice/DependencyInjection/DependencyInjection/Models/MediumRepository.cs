using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class MediumRepository : IEntranceRepository /*IMediumRepository*/
    {
        public IEnumerable<Product> Products { get { return products; } }

        public IEnumerable<Product> products = new List<Product>()
        {
            new Product
            {
                ID = 1,
                Name = "C#",
                Descripton = "Programming C#",
                Category = "Books",
                Price = 1080
            },

            new Product
            {
                ID = 2,
                Name = "ASP.NET Core",
                Descripton = "Framework ASP.NET Core MVC 2.0",
                Category = "Books",
                Price = 1300
            },

            new Product
            {
                ID = 3,
                Name = "Entity Framework Core",
                Descripton = "Entity Framework Core 2.0",
                Category = "Books",
                Price = 830
            }
        };
    }
}
