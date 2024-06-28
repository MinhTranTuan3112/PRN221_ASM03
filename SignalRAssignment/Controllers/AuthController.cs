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
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        private readonly IServiceFactory _serviceFactory;

        public AuthController(ILogger<AuthController> logger, IServiceFactory serviceFactory)
        {
            _logger = logger;
            _serviceFactory = serviceFactory;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(IFormCollection form)
        {

            string email = form["email"]!;
            string password = form["password"]!;
            var appUser = await _serviceFactory.AppUserService.SignIn(email, password);
            HttpContext.Session.SetString("userId", appUser.UserID.ToString());

            return RedirectToAction("Index", "Posts");

        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(IFormCollection form)
        {
            string email = form["email"]!;
            string password = form["password"]!;
            string fullName = form["fullName"]!;
            var address = form["address"];

            await _serviceFactory.AppUserService.SignUp(new SignUpRequest
            {
                Email = email,
                Password = password,
                FullName = fullName,
                Address = address
            });

            return RedirectToAction("Login", "Home", new { message = "Please login to join our posts community!" });
        }

        [HttpGet("signout")]
        public IActionResult PerformSignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}