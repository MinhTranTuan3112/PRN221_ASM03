using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.BusinessLogic.BusinessModels;
using SignalRAssignment.BusinessLogic.RequestModels;

namespace SignalRAssignment.BusinessLogic.Interfaces
{
    public interface IPostService
    {
        Task<List<PostModel>> GetPosts(string keyword = "");

        Task<PostDetailsModel> GetPostDetailsById(int postId); 

        Task UpdatePost(int postId, UpdatePostRequest request);

        Task<int> CreatePost(CreatePostRequest request);

        Task DeletePost(int postId);
        
    }
}