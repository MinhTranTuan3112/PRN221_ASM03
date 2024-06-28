using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using SignalRAssignment.BusinessLogic.BusinessModels;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.DataAccess.Interfaces;

namespace SignalRAssignment.BusinessLogic.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PostCategoryModel>> GetCategories()
        {
            return (await _unitOfWork.PostCategoryRepository.GetAllAsync()).Adapt<List<PostCategoryModel>>();
        }
    }
}