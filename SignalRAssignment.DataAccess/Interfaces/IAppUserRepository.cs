using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.Shared.BusinessModels;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.DataAccess.Interfaces
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
        Task<AppUser?> GetAppUserDetailsById(int id);
        Task<PagedResultModel<AppUser>> GetPagedAppUsers(QueryPagedAppUsersRequest request);
    }
}