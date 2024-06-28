using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalRAssignment.ResponseModels;

namespace SignalRAssignment.Controllers
{
    [Route("[controller]")]
    public class CustomErrorController : Controller
    {
        
        public CustomErrorController()
        {
            
        }

        public IActionResult Index(string message, int statusCode)
        {

            return View("~/Views/CustomError.cshtml", new CustomErrorPageResponse
            {
                Message = message,
                StatusCode = statusCode
            });
        }
    }
}