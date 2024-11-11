using API_Server.Data;
using API_Server.Models;
using API_Server.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.Configuration;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
var builder = WebApplication.CreateBuilder(args);


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
builder.Services.AddScoped<FilmService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<ImgurService>();
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<MongoDbContext>();



builder.Services.AddAuthorization();

var JWTSettings = builder.Configuration.GetSection("JWT").Get<JWT>();
builder.Services.AddSingleton<JWT>(JWTSettings);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
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
                return context.Response.WriteAsync("{\"message\":\"Không thể xác thực người dùng.\"}");
            }
        };
    });

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapIdentityApi<IdentityUser>();

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
}