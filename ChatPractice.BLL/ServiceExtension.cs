using ChatPractice.BLL.Services.ConversationService;
using ChatPractice.BLL.Services.MessageService;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.BLL.Services.UserService;
using Microsoft.Extensions.DependencyInjection;
using ChatPractice.BLL.Services;
using ChatPractice.DAL;

namespace ChatPractice.BLL;
public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IConversationService, ConversationService>();

        services.AddScoped<IConfigurationService, ConfigurationService>();
    }
}
