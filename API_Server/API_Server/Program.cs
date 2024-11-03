using API_Server.Data;
using API_Server.Models;
using API_Server.Service;
using MongoDB.Driver;
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

/*builder.Services.AddScoped<IMongoCollection<Video>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    return database.GetCollection<Video>("Videos"); 
});*/


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*public class MongoDbContext
{
    private readonly IMongoDatabase _db;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("ConnectionString"));
        _db = client.GetDatabase("DOAN");
    }

    public IMongoCollection<User> Users => _db.GetCollection<User>("User");
    public IMongoCollection<TokenData> Tokens => _db.GetCollection<TokenData>("Token");
}*/