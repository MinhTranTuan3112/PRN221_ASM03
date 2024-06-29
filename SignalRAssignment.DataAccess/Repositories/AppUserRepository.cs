using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.DataAccess.Extensions;
using SignalRAssignment.DataAccess.Interfaces;
using SignalRAssignment.Shared.BusinessModels;
using SignalRAssignment.Shared.RequestModels;

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

        public async Task<PagedResultModel<AppUser>> GetPagedAppUsers(QueryPagedAppUsersRequest request)
        {
            var query = _context.AppUsers.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(a => a.Fullname.ToLower().Contains(request.Keyword.ToLower()));
            }


            return await query.ToPagedResultModelAsync(request.Page, request.PageSize);
        }
    }
}