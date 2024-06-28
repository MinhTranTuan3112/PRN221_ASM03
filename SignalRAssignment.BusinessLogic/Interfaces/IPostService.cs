using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.Shared.BusinessModels;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.BusinessLogic.Interfaces
{
    public interface IPostService
    {
        Task<PagedResultModel<PostDetailsModel>> GetPagedPosts(QueryPagedPostRequest request);

        Task<PostDetailsModel> GetPostDetailsById(int postId); 

        Task UpdatePost(int postId, UpdatePostRequest request);

        Task<int> CreatePost(CreatePostRequest request);

        Task DeletePost(int postId);
        
    }
}