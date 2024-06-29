using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.DataAccess.Interfaces;
using SignalRAssignment.Shared.BusinessModels;
using SignalRAssignment.Shared.Exceptions;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.BusinessLogic.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUserDetailsModel> GetAppUserDetailsById(int id)
        {
            var appUser = await _unitOfWork.AppUserRepository.GetAppUserDetailsById(id);

            if (appUser is null)
            {
                throw new NotFoundException("user not found");
            }

            return appUser.Adapt<AppUserDetailsModel>();
        }

        public async Task<List<AppUserModel>> GetAppUsers()
        {
            return (await _unitOfWork.AppUserRepository.GetAllAsync()).Adapt<List<AppUserModel>>();
        }


        public async Task SignUp(SignUpRequest request)
        {
            if (!await _unitOfWork.AppUserRepository.AnyAsync(u => u.Email == request.Email))
            {
                throw new Exception("Email already exist!");
            }

            var appUser = request.Adapt<AppUser>();
            await _unitOfWork.AppUserRepository.AddAsync(appUser);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<AppUserModel> SignIn(string email, string password)
        {
            var appUser = await _unitOfWork.AppUserRepository.FindOneAsync(u => u.Email == email && u.Password == password);

            if (appUser is null)
            {
                throw new UnauthorizedException("Wrong email or password");
            }

            return appUser.Adapt<AppUserModel>();
        }

        public async Task UpdateAppUser(int appUserId, UpdateAppUserRequest request)
        {
            var appUser = await _unitOfWork.AppUserRepository.FindOneAsync(a => a.UserID == appUserId);

            if (appUser is null)
            {
                throw new NotFoundException("User not found");
            }

            request.Adapt(appUser);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResultModel<AppUserModel>> GetPagedAppUsers(QueryPagedAppUsersRequest request)
        {
            return (await _unitOfWork.AppUserRepository.GetPagedAppUsers(request)).Adapt<PagedResultModel<AppUserModel>>();
        }
    }
}