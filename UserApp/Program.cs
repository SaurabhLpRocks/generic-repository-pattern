using Microsoft.EntityFrameworkCore;
using UserApp.Api.Settings;
using UserApp.Data.Repositories.Base;
using UserApp.Data.Repositories.Interfaces;
using UserApp.Data.UoW;
using UserApp.EFCore.Models;
using UserApp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var appSettings = config.GetSection("AppSettings").Get<AppSettings>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserAppDbContext>(options => options.UseSqlServer(appSettings.ConnectionStrings.UserAppDb));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();

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
