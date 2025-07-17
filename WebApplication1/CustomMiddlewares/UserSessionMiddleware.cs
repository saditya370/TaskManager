using System.Security.Claims;

namespace TaskManager.api.CustomMiddlewares
{
    public class UserSessionMiddleware
    {
        private readonly RequestDelegate _next;

        public UserSessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            if (context.User.Identity.IsAuthenticated)
            {
              
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var username = context.User.FindFirst(ClaimTypes.Name)?.Value;
                var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
                context.Items["UserId"] = userId;
                context.Items["Username"] = username;
                context.Items["Email"] = email;
            }
          
            await _next(context);
        }
    }
}
