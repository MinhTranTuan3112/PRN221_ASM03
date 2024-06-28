using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAssignment.BusinessLogic.Hubs;
using SignalRAssignment.BusinessLogic.Interfaces;

namespace SignalRAssignment.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static WebApplication MapCustomEndpoints(this WebApplication app)
        {
            app.MapGet("/api/posts", async (IPostService _postService) =>
            {
                return await _postService.GetPosts();
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