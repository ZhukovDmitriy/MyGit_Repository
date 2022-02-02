using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationForCash.Models;

namespace ApplicationForCash.Infrastructure.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Role> Roles { get; }
    }
}
