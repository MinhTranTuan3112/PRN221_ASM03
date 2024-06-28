using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.DataAccess.Interfaces;

namespace SignalRAssignment.DataAccess.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        private readonly ApplicationDbContext _context;
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetAppUserDetailsById(int id)
        {
            return await _context.AppUsers.Include(a => a.Posts)
                                        .SingleOrDefaultAsync(a => a.UserID == id);
        }
    }
}