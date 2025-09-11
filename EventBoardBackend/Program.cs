using EventBoardBackend.Data;
using EventBoardBackend.Services;
using EventBoardBackend.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(opt =>
//{
//    opt.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = builder.Configuration.GetSection("JwtSettings")["Issuer"],
//        ValidAudience = builder.Configuration.GetSection("JwtSettings")["Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings")["Key"])),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true
//    };
//});

builder.Services.AddDbContextPool<AppDbContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtOptions")["SecretKey"])),
            RoleClaimType = "userRole"
        };

        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["token-cookie"];
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization(opt =>
{
    {
        opt.AddPolicy("AdminPolicy", policy =>
        {
            policy.RequireRole("ADMIN");
        });
        opt.AddPolicy("ManagerPolicy", policy =>
        {
            policy.RequireRole("MANAGER");
        });
        opt.AddPolicy("StudentPolicy", policy =>
        {
            policy.RequireRole("STUDENT");
        });

    }
});
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddSingleton<PasswordHasher>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));
builder.Services.AddScoped<JwtProvider>();


builder.Services.AddScoped<AccountService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Event Board",
        Description = "HITS test",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
