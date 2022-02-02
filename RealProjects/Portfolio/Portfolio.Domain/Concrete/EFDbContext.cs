using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;
using System.Data.Entity;

namespace Portfolio.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
