using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.Controllers
{
    [Route("[controller]")]
    public class AppUsersController : Controller
    {
        private readonly ILogger<AppUsersController> _logger;

        private readonly IServiceFactory _serviceFactory;

        public AppUsersController(ILogger<AppUsersController> logger, IServiceFactory serviceFactory)
        {
            _logger = logger;
            _serviceFactory = serviceFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] QueryPagedAppUsersRequest request)
        {
            var pagedResult = await _serviceFactory.AppUserService.GetPagedAppUsers(request);
            ViewBag.keyword = request.Keyword;
            return View("~/Views/AppUsers/Index.cshtml", pagedResult);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}