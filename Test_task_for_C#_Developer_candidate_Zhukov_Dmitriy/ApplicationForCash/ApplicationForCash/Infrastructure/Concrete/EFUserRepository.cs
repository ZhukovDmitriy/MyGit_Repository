using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationForCash.Infrastructure.Abstract;
using ApplicationForCash.Models;

namespace ApplicationForCash.Infrastructure.Concrete
{
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
