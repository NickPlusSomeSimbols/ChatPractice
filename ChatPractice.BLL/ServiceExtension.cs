﻿using ChatPractice.BLL.Services.MessageService;
using ChatPractice.BLL.Services.SimpleUserService;
using Microsoft.Extensions.DependencyInjection;

namespace ChatPractice.BLL;
public static class ServiceExtension
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMessageService, MessageService>();
    }
}
