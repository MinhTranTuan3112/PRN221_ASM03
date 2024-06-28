using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.SignalR;
using SignalRAssignment.BusinessLogic.Hubs;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.DataAccess.Interfaces;
using SignalRAssignment.Shared.BusinessModels;
using SignalRAssignment.Shared.Exceptions;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.BusinessLogic.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHubContext<PostHub> _postHubContext;

        public PostService(IUnitOfWork unitOfWork, IHubContext<PostHub> postHubContext)
        {
            _unitOfWork = unitOfWork;
            _postHubContext = postHubContext;
        }

        public async Task<int> CreatePost(CreatePostRequest request)
        {
            var post = request.Adapt<Post>();

            post.CreatedDate = DateTime.Now;


            await _unitOfWork.PostRepository.AddAsync(post);
            await _unitOfWork.SaveChangesAsync();

            //Notify the client
            await _postHubContext.Clients.All.SendAsync("ReceivePostUpdate", post.PostID);

            return post.PostID;
        }

        public async Task DeletePost(int postId)
        {
            if (!await _unitOfWork.PostRepository.AnyAsync(p => p.PostID == postId))
            {
                throw new NotFoundException("Post not found");
            }

            await _unitOfWork.PostRepository.ExecuteDeleteAsync(p => p.PostID == postId);
            await _unitOfWork.SaveChangesAsync();

            //Notify the client
            await _postHubContext.Clients.All.SendAsync("ReceivePostDeleted");
        }

        public async Task<PostDetailsModel> GetPostDetailsById(int postId)
        {
            var post = await _unitOfWork.PostRepository.GetPostDetailsById(postId);

            if (post is null)
            {
                //Handle not found
                throw new NotFoundException("Post not found");
            }

            return post.Adapt<PostDetailsModel>();
        }

        public async Task<PagedResultModel<PostModel>> GetPagedPosts(QueryPagedPostRequest request)
        {
            return (await _unitOfWork.PostRepository.GetPagedPosts(request)).Adapt<PagedResultModel<PostModel>>();
        }

        public async Task UpdatePost(int postId, UpdatePostRequest request)
        {
            var post = await _unitOfWork.PostRepository.FindOneAsync(p => p.PostID == postId);

            if (post is null)
            {
                //Handle not found
                throw new NotFoundException("Post not found");
            }

            request.Adapt(post);

            post.UpdatedDate = DateTime.Now;


            await _unitOfWork.SaveChangesAsync();

            //Notify the client
            await _postHubContext.Clients.All.SendAsync("ReceivePostUpdate", post.PostID);

        }
    }
}