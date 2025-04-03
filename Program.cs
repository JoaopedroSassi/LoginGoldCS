using LoginGoldCS.Extensions;
using LoginGoldCS.Models.Configuration;
using LoginGoldCS.Models.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDependencyInjections();

//Configuring MongoDB
var urlMongoDb = Environment.GetEnvironmentVariable("CONNECTIONSTRING");

if (string.IsNullOrEmpty(urlMongoDb))
{
    throw new Exception("A vari�vel de ambiente CONNECTIONSTRING n�o est� definida.");
}

Console.WriteLine($"Usando Connection String do ambiente: {urlMongoDb}");

var mongoUrl = new MongoUrl(urlMongoDb);
var databaseName = mongoUrl.DatabaseName ?? throw new Exception("Nome do banco de dados n�o encontrado na connection string.");

builder.Services.Configure<MongoDBConfig>(options =>
{
    options.ConnectionString = urlMongoDb;
    options.DatabaseName = databaseName;
});

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(sp.GetRequiredService<IOptions<MongoDBConfig>>().Value.ConnectionString));

builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBConfig>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

//Mapping
BsonClassMap.RegisterClassMap<Login>(cm =>
{
    cm.AutoMap();
    cm.MapMember(c => c.Email).SetElementName("email");
    cm.MapMember(c => c.Password).SetElementName("password");
});

// Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();