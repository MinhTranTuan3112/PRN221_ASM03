using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SignalRAssignment.Shared.Exceptions;

namespace SignalRAssignment.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"An error occurred: {ex.Message}");
                HandleException(httpContext, ex);
            }
        }

        private void HandleException(HttpContext httpContext, Exception ex)
        {

            int statusCode = (int)HttpStatusCode.InternalServerError;
            string encodedMessage = Uri.EscapeDataString(ex.Message);
            string redirectPath = $"/CustomError?message={encodedMessage}&statusCode={statusCode}";

            switch (ex)
            {
                case NotFoundException _:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ForbiddenMethodException _:
                    statusCode = (int)HttpStatusCode.Forbidden;
                    redirectPath = $"/Home/Login?message={encodedMessage}";
                    break;
                case UnauthorizedException _:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    redirectPath = $"/Home/Login?message={encodedMessage}";
                    break;
                default:
                    break;
            }

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.Redirect(redirectPath);
        }
    }
}