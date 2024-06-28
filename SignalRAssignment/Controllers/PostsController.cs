using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRAssignment.Attributes;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.BusinessLogic.RequestModels;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.ResponseModels;

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
        public async Task<IActionResult> Index(string keyword = "")
        {
            var posts = await _serviceFactory.PostService.GetPosts(keyword);

            ViewBag.keyword = keyword;

            return View("~/Views/Posts/Index.cshtml", posts);
        }

        [HttpGet("create")]
        [SessionAuthorize]
        public async Task<IActionResult> Create()
        {
            var categories = await _serviceFactory.PostCategoryService.GetCategories();

            var appUsers = await _serviceFactory.AppUserService.GetAppUsers();

            return View("~/Views/Posts/PostDetails.cshtml", new PostDetailPageResponse
            {
                Action = "Create",
                PostCategories = categories,
                AppUsers = appUsers
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var post = await _serviceFactory.PostService.GetPostDetailsById(id);

            var categories = await _serviceFactory.PostCategoryService.GetCategories();

            var appUsers = await _serviceFactory.AppUserService.GetAppUsers();

            return View("~/Views/Posts/PostDetails.cshtml", new PostDetailPageResponse
            {
                Post = post,
                PostCategories = categories,
                AppUsers = appUsers,
                Action = "Update"
            });
        }

        [HttpPost("{id}")]
        [SessionAuthorize]
        public async Task<IActionResult> Upsert([FromRoute] int id, [FromForm] IFormCollection form)
        {
            string action = form["action"]!;

            if (action.ToLower() is "update")
            {
                await _serviceFactory.PostService.UpdatePost(id, new UpdatePostRequest
                {
                    Title = form["title"]!,
                    Content = form["content"]!,
                    PublishStatus = form["publishStatus"]!,
                    CategoryID = Convert.ToInt32(form["category"]),
                    AuthorID = Convert.ToInt32(form["author"]!)
                });

                ViewBag.Message = "Post updated successfully";

                return RedirectToAction("Details", "Posts", new { id });

            }

            int postId = await _serviceFactory.PostService.CreatePost(new CreatePostRequest
            {
                Title = form["title"]!,
                Content = form["content"]!,
                PublishStatus = form["publishStatus"]!,
                CategoryID = Convert.ToInt32(form["category"]),
                AuthorID = Convert.ToInt32(form["author"]!)
            });

            ViewBag.Message = "Created new post successfully";

            return RedirectToAction("Details", "Posts", new { id = postId });

        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _serviceFactory.PostService.DeletePost(id);
            return RedirectToAction("Index", "Posts");
        }

    }
}