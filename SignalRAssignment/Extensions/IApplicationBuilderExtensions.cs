using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalRAssignment.BusinessLogic.Hubs;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static WebApplication MapCustomEndpoints(this WebApplication app)
        {
            app.MapGet("/api/posts", async (IPostService _postService,
                        int page = 1, int pageSize = 10, string keyword = "") =>
            {
                return await _postService.GetPagedPosts(new QueryPagedPostRequest
                {
                    Page = page,
                    PageSize = pageSize,
                    Keyword = keyword
                });
            });

            app.MapGet("/api/posts/user/{userId}", async (IPostService _postService, int userId) =>
            {
                return await _postService.GetPostsByUserId(userId);
            });

            app.MapGet("/api/appusers/{id}", async (IAppUserService _appUserService, int id) =>
            {
                return await _appUserService.GetAppUserDetailsById(id);
            });



            return app;
        }

        public static WebApplication MapSignalRHubs(this WebApplication app)
        {
            app.MapHub<PostHub>("/postHub");
            return app;
        }
    }
}