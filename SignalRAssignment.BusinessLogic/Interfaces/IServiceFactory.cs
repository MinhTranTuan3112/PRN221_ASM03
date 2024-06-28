using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAssignment.BusinessLogic.Interfaces
{
    public interface IServiceFactory
    {
        IPostService PostService { get; }

        IPostCategoryService PostCategoryService { get; }

        IAppUserService AppUserService { get; }
    }
}