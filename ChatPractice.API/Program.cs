using ChatPractice.BLL;
using ChatPractice.BLL.Helpers;
using ChatPractice.BLL.Services.Middlewares;
using ChatPractice.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureServices();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DockerPostgres")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
//.AddScheme<AuthenticationSchemeOptions, UserAuthenticationHandler>("MyScheme", options => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<UserAuthorizationMiddleware>();

app.MapControllers();

app.Run();
