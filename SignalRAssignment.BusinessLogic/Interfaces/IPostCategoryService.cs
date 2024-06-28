using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.Shared.BusinessModels;

namespace SignalRAssignment.BusinessLogic.Interfaces
{
    public interface IPostCategoryService
    {
        Task<List<PostCategoryModel>> GetCategories();
    }
}