using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpResponseExcption ex)
            {
                HandlerRequestExceptionAsync(httpContext, ex);
            }
        }

        private static void HandlerRequestExceptionAsync(
            HttpContext context, CustomHttpResponseExcption httpResponseExcption)
        {
            if (httpResponseExcption.StatusCode == HttpStatusCode.Unauthorized)
            {
                context.Response.Redirect($"/login?ReturnUrl={context.Request.Path}");
                return;
            }

            context.Response.StatusCode = (int)httpResponseExcption.StatusCode;
        }
    }
}
