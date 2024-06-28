using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SignalRAssignment.Shared.Exceptions;

namespace SignalRAssignment.Attributes
{
    public class SessionAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            var userId = httpContext.Session.GetString("userId");

            if (string.IsNullOrEmpty(userId))
            {
                // Redirect to the login page if the user is not logged in
                // context.Result = new RedirectToActionResult("Login", "Home", null);
                throw new ForbiddenMethodException("You are not allowed to access this resource!");
            }
        }
    }
}