using ChatPractice.BLL.Services.MessageService;
using ChatPractice.BLL.Services.SimpleUserService;
using DocketTest_1;
using DocketTest_1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISimpleUserService, SimpleUserService>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddDbContext<DbOneContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
