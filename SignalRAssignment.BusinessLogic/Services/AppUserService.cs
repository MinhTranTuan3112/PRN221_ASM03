using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SignalRAssignment.BusinessLogic.BusinessModels;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.DataAccess.Interfaces;
using SignalRAssignment.Shared.Exceptions;

namespace SignalRAssignment.BusinessLogic.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AppUserModel>> GetAppUsers()
        {
            return (await _unitOfWork.AppUserRepository.GetAllAsync()).Adapt<List<AppUserModel>>();
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
    }
}