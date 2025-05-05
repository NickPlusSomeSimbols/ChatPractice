using ChatPractice.BLL.Attributes;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace ChatPractice.BLL.Services.Middlewares;

public class UserAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public UserAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!SkipPermissionCheck(context))
        {
            var userConfiguration = context.RequestServices.GetRequiredService<IUserSessionService>();
            var db = context.RequestServices.GetRequiredService<AppDbContext>();

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync("Access denied");

                return;
            }

            long parsedUserId = long.Parse(userId);

            var user = await db.Users.FindAsync(parsedUserId);
            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new { error = "User not found" });
                return;
            }

            userConfiguration.CurrentUser = user;
        }

        await _next(context);
    }

    private bool SkipPermissionCheck(HttpContext context)
    {
        var endpoint = context.GetEndpoint();

        if (endpoint == null)
        {
            return false;
        }

        var controllerActionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

        if (controllerActionDescriptor == null)
        {
            return false;
        }

        var controllerHasAttribute = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(true)
            .Any(attr => attr.GetType() == typeof(SkipPermissionCheckAttribute));

        if (controllerHasAttribute)
        {
            return true;
        }

        var actionHasAttribute = controllerActionDescriptor.MethodInfo.GetCustomAttributes(true)
            .Any(attr => attr.GetType() == typeof(SkipPermissionCheckAttribute));

        return actionHasAttribute;
    }
}