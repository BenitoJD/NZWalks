using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace NZWalksAPI.Middleware
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandler(ILogger<ExceptionHandlerMiddleware> logger
            ,RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContent) 
        {
            try
            {
                await next(httpContent);
            }
            catch (Exception ex) 
            {

                var errorID = Guid.NewGuid();
                logger.LogError(ex, $"{errorID} : {ex.Message}");
                httpContent.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContent.Response.ContentType = "application/json";

                var error = new 
                {
                    Id = errorID,
                    ErrorMessage = "Something went wrong we are looking into resolving this",
                };

                await httpContent.Response.WriteAsJsonAsync(error);

                throw;
            }
        }
    }
}
