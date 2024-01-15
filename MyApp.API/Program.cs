using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyApp.Data;
using MyApp.IRepositories;
using MyApp.IServices;
using MyApp.Model;
using MyApp.Repositories;
using MyApp.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettingsSection);

builder.Services.AddDbContext<EMDbContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MyApp.API"));
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IPersonalDetailRepository, PersonalDetailRepository>();
builder.Services.AddScoped<IPersonalDetailsService, PersonalDetailsService>();

builder.Services.AddScoped<IEmploymentDetailsRepository, EmploymentDetailRepository>();
builder.Services.AddScoped<IEmploymentDetailsService, EmploymentDetailsService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();

builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<JwtSettings>>().Value);
var jwtSetting = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;
var secretKey = Encoding.ASCII.GetBytes(jwtSetting.SecretKey);

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });
});

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("EnableCORS");
app.MapControllers();
app.MapGet("/", () => "Hello Akshay");
app.Run();







//using Microsoft.EntityFrameworkCore;
//using MyApp.Data;

//var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<EMDbContext>(options =>
//{
//    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MyApp.API"));
//    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
//    options.EnableSensitiveDataLogging(); // This option includes parameter values in the log output
//    options.LogTo(Console.WriteLine);
//});

//builder.Services.AddControllers();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("EnableCORS", builder =>
//    {
//        builder.AllowAnyOrigin()
//           .AllowAnyMethod()
//           .AllowAnyHeader();
//    });
//});


//var app = builder.Build();
//app.MapControllers();
//app.UseCors("EnableCORS");

//app.MapGet("/", () => "Hello World!");

//app.Run();