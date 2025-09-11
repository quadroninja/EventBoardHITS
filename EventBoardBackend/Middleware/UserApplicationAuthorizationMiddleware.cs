
namespace EventBoardBackend.Middleware
{
    public class UserApplicationAuthorizationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {


            await next(context);
        }
    }
}
