using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class SmallRepository : IEntranceRepository /* ISmallRepository*/
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
            }
        };
    }
}
