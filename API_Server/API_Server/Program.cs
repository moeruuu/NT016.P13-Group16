using API_Server.Models;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();

public class MongoDbContext
{
    private readonly IMongoDatabase _db;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("ConnectionString"));
        _db = client.GetDatabase("");
    }

    public IMongoCollection<User> Users => _db.GetCollection<User>("User");
    public IMongoCollection<TokenData> Tokens => _db.GetCollection<TokenData>("Token");
}