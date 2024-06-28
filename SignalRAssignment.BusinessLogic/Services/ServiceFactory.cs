using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRAssignment.BusinessLogic.Hubs;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.DataAccess.Interfaces;

namespace SignalRAssignment.BusinessLogic.Services
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly Lazy<IPostService> _postService;

        private readonly Lazy<IPostCategoryService> _postCategoryService;
        
        private readonly Lazy<IAppUserService> _appUserService;

        public ServiceFactory(IUnitOfWork unitOfWork, IHubContext<PostHub> postHubContext)
        {
            _postService = new Lazy<IPostService>(() => new PostService(unitOfWork, postHubContext));
            _postCategoryService = new Lazy<IPostCategoryService>(() => new PostCategoryService(unitOfWork));
            _appUserService = new Lazy<IAppUserService>(() => new AppUserService(unitOfWork));
        }

        public IPostService PostService => _postService.Value;

        public IPostCategoryService PostCategoryService => _postCategoryService.Value;

        public IAppUserService AppUserService => _appUserService.Value;
    }
}