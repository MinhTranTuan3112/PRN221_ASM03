using Microsoft.AspNetCore.Mvc;
using SignalRAssignment.Models;
using System.Diagnostics;

namespace SignalRAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string message = "")
        {
            ViewBag.Message = message;
            return View("~/Views/Login.cshtml");
        }

        public IActionResult Register(string message = "")
        {
            ViewBag.Message = message;
            return View("");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
