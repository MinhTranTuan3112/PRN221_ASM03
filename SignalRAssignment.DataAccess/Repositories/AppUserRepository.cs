using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.DataAccess.Interfaces;

namespace SignalRAssignment.DataAccess.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}