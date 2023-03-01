using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserMgr.Domain;
using UserMgr.Infrastracture;
using UserMgr.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<MvcOptions>(x =>
{
    x.Filters.Add<UnitOfWorkFilter>();
});
builder.Services.AddDbContext<UserDbContext>(x =>
{
    x.UseMySql("Server=localhost;User ID=root;Password=123456;DataBase=ddd1",
        new MySqlServerVersion(new Version(8, 0, 30)));
});
builder.Services.AddMemoryCache();
builder.Services.AddMediatR(x=>x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<UserDomainService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISmsCodeSender, MockSmsCodeSender>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
