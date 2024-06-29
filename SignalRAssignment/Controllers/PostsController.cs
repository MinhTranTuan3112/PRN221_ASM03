using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRAssignment.Attributes;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.ResponseModels;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.Controllers
{
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;

        private readonly IServiceFactory _serviceFactory;

        public PostsController(ILogger<PostsController> logger, IServiceFactory serviceFactory)
        {
            _logger = logger;
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] QueryPagedPostRequest request)
        {
            var pagedResult = await _serviceFactory.PostService.GetPagedPosts(request);

            ViewBag.keyword = request.Keyword;

            return View("~/Views/Posts/Index.cshtml", pagedResult);
        }

        [HttpGet("create")]
        [SessionAuthorize]
        public async Task<IActionResult> Create()
        {
            var categories = await _serviceFactory.PostCategoryService.GetCategories();

            return View("~/Views/Posts/PostDetails.cshtml", new PostDetailPageResponse
            {
                Action = "Create",
                PostCategories = categories,
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var post = await _serviceFactory.PostService.GetPostDetailsById(id);

            var categories = await _serviceFactory.PostCategoryService.GetCategories();

            return View("~/Views/Posts/PostDetails.cshtml", new PostDetailPageResponse
            {
                Post = post,
                PostCategories = categories,
                Action = "Update"
            });
        }

        [HttpPost("create-new-post")]
        [SessionAuthorize]
        public async Task<IActionResult> CreateNewPost(IFormCollection form)
        {
            string action = form["action"]!;
            if (action.ToLower() is not "create")
            {
                return RedirectToAction("Index", "Posts");
            }
        
            int postId = await _serviceFactory.PostService.CreatePost(new CreatePostRequest
            {
                Title = form["title"]!,
                Content = form["content"]!,
                PublishStatus = form["publishStatus"]!,
                CategoryID = Convert.ToInt32(form["category"]),
                AuthorID = Convert.ToInt32(HttpContext.Session.GetString("userId"))
            });

            ViewBag.Message = "Created new post successfully";

            return RedirectToAction("Details", "Posts", new { id = postId });


        }

        [HttpPost("{id}")]
        [SessionAuthorize]
        public async Task<IActionResult> UpdatePost([FromRoute] int id, [FromForm] IFormCollection form)
        {
            string action = form["action"]!;

            if (action.ToLower() is not "update")
            {
                return RedirectToAction("Index", "Posts");
            }

            await _serviceFactory.PostService.UpdatePost(id, new UpdatePostRequest
            {
                Title = form["title"]!,
                Content = form["content"]!,
                PublishStatus = form["publishStatus"]!,
                CategoryID = Convert.ToInt32(form["category"]),
                AuthorID = Convert.ToInt32(HttpContext.Session.GetString("userId"))
            });

            ViewBag.Message = "Post updated successfully";

            return RedirectToAction("Details", "Posts", new { id });

        }

        [HttpDelete("/delete/{id}")]
        [SessionAuthorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("userId"));

            await _serviceFactory.PostService.DeletePost(userId, id);
            return RedirectToAction("Index", "Posts");
        }

    }
}