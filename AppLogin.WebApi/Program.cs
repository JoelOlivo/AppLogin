using Microsoft.EntityFrameworkCore;
using AppLogin.Infrastructure.Data.DbContexts;
using AppLogin.Application.UserAdd;
using AppLogin.Application.UserUpdate;
using AppLogin.Application.UserDelete;
using AppLogin.Application.UserGetById;
using AppLogin.Application.UserGetAll;
using AppLogin.Domain.Interfaces;
using AppLogin.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregar contexto de base de datos
builder.Services.AddDbContext<AppLoginDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserAdd>();
builder.Services.AddScoped<UserUpdate>();
builder.Services.AddScoped<UserDelete>();
builder.Services.AddScoped<UserGetById>();
builder.Services.AddScoped<UserGetAll>();


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
