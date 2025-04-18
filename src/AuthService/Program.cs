using AuthService.Endpoints;
using AuthService.Interfaces.Users;
using AuthService.Repositories;
using AuthService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.AutoMapper;
using Shared.Config;
using Shared.Database;
using Shared.Interfaces;
using Shared.Repositories;
using Shared.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Swagger

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Configuration

builder.Services.Configure<Configuration>(builder.Configuration);

#endregion

#region Database

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

#endregion

#region Services

builder.Services.AddTransient<IUserService, UserService>();

#endregion

#region Repositories

builder.Services.AddTransient<IUserRepository, UserRepository>();

#endregion

#region Mapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion

#region Auth

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtConfig = builder.Configuration.GetSection("Jwt");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig[nameof(TokenValidationParameters.ValidIssuer)],
            ValidAudience = jwtConfig[nameof(TokenValidationParameters.ValidAudience)],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"] ?? throw new SecurityTokenException("JwtConfig Key was null on appsettings.json")))
        };
    });

builder.Services.AddAuthorizationBuilder();

#endregion

var app = builder.Build();

#region Endpoints

app.RegisterAuthEndpoints();

#endregion

#region HttpConfig

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#endregion

app.Run();