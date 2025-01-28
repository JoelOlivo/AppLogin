using Microsoft.EntityFrameworkCore;
using AppLogin.Infrastructure.Data.DbContexts;
using AppLogin.Application.UserAdd;
using AppLogin.Application.UserUpdate;
using AppLogin.Application.UserDelete;
using AppLogin.Application.UserGetById;
using AppLogin.Application.UserGetAll;
using AppLogin.Application.UserLogin;
using AppLogin.Domain.Interfaces;
using AppLogin.Infrastructure.Repositories;
using AppLogin.Application.Interfaces;
using AppLogin.Infrastructure.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Agregar contexto de base de datos
builder.Services.AddDbContext<AppLoginDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IJwtGenerator, JwtGenerator>();
builder.Services.AddScoped<UserAdd>();
builder.Services.AddScoped<UserUpdate>();
builder.Services.AddScoped<UserDelete>();
builder.Services.AddScoped<UserGetById>();
builder.Services.AddScoped<UserGetAll>();
builder.Services.AddScoped<UserLogin>();

var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// Agregar servicios CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthentication(); // Activar autenticación

app.UseAuthorization();

app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
