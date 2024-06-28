using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.Shared.BusinessModels;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.BusinessLogic.Interfaces
{
    public interface IAppUserService
    {
        Task<List<AppUserModel>> GetAppUsers();

        Task<AppUserModel> SignIn(string email, string password); 

        Task SignUp(SignUpRequest request);

        Task<AppUserDetailsModel> GetAppUserDetailsById(int id);

        Task UpdateAppUser(int appUserId, UpdateAppUserRequest request);
        
    }
}