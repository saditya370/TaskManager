using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Exceptions;

namespace TaskManager.api.CustomMiddlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorisedException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(GetProblemDetails("Unauthorised User", ex, context));
            }
            catch (NotFoundException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(GetProblemDetails("Resource Not Found", ex, context));
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(GetProblemDetails("Some Thing went wrong", ex, context));
            }

            //After or in return 
        }

        private ProblemDetails GetProblemDetails(string message, Exception ex, HttpContext context)
        {
            return new ProblemDetails()
            {
                Title = message,
                Status = context.Response.StatusCode,
                Detail = ex.Message,
                Instance = context.Request.Path,
                Extensions =
                    {
                        ["ErrorMessage"] = ex.Message
                    }
            };
        }
    }
    }
}
