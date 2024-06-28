using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.Shared.BusinessModels;

namespace SignalRAssignment.BusinessLogic.Interfaces
{
    public interface IAppUserService
    {
        Task<List<AppUserModel>> GetAppUsers();

        Task<AppUserModel> SignIn(string email, string password); 
    }
}