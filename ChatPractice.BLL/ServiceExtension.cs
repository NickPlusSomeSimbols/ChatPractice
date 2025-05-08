using ChatPractice.BLL.Services.MessageService;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.BLL.Services.UserService;
using Microsoft.Extensions.DependencyInjection;
using ChatPractice.BLL.Services;
using ChatPractice.DAL;
using Microsoft.AspNetCore.Http;
using ChatPractice.DAL.Repository;

namespace ChatPractice.BLL;
public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSessionService, UserSessionService>();

        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IChatRepository, ChatRepository>();
    }
}
