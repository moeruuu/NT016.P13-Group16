using API_Server.Data;
using API_Server.Models;
using API_Server.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Configuration;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API_Server.SignalRHub;
using API_Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddSignalR();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
    return client.GetDatabase("DOAN"); 
});

builder.Services.Configure<EmailSender>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<VideoService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<ImgurService>();
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<MongoDbContext>();
builder.Services.AddScoped<CoopService>();
builder.Services.AddScoped<EncryptionService>();

builder.Services.AddAuthorization();

var JWTSettings = builder.Configuration.GetSection("JWT").Get<JWT>();
builder.Services.AddSingleton<JWT>(JWTSettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JWTSettings.Issuer,
            ValidAudience = JWTSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSettings.SecretKey)),
        };
        options.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsJsonAsync(new { message = "Unauthorized access." });
            },
            OnTokenValidated = context =>
            {
                var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                var roleClaim = claimsIdentity?.FindFirst("Role");

                if (roleClaim != null)
                {
                    var roleValue = roleClaim.Value == "0" ? "Admin" : "User";
                    claimsIdentity.RemoveClaim(roleClaim);
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, roleValue));
                }

                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

app.MapHub<VideoHub>("/videohub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapIdentityApi<IdentityUser>();

app.UseCors("AllowAll");
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public class MongoDbContext
{
    private readonly IMongoDatabase _db;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
        _db = client.GetDatabase("DOAN");
    }

    public IMongoCollection<User> Users => _db.GetCollection<User>("Users");
    public IMongoCollection<Token> Tokens => _db.GetCollection<Token>("JWTToken");
    public IMongoCollection<Room> Rooms => _db.GetCollection<Room>("Rooms");
}