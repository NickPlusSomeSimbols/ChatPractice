using ChatPractice.BLL.Services.ConversationService;
using ChatPractice.BLL.Services.MessageService;
using ChatPractice.BLL.Services.SessionService;
using ChatPractice.BLL.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace ChatPractice.BLL;
public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IConversationService, ConversationService>();
    }
}
