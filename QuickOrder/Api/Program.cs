using Api.Configurations;
using Domain.Entities;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using static Infra.MongoDB.DbConnectionModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("QuickOrderDatabase"));
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings")
);

builder.Services.AddSingleton<IMongoDatabase>(options => {
    var settings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

BsonClassMap.RegisterClassMap<Produto>(map =>
{
    map.AutoMap();
    map.SetIgnoreExtraElements(true);
    map.MapIdMember(x => x.Id);
    map.MapMember(x => x.Nome).SetIsRequired(true);
    map.MapMember(x => x.CategoriaId).SetIsRequired(true);
    map.MapMember(x => x.Preco).SetIsRequired(true);
    map.MapMember(x => x.Descricao).SetIsRequired(false);
    map.MapMember(x => x.Foto).SetIsRequired(false);
    //  map.MapMember(x => x.ProdutoItems).SetIsRequired(false);
});

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
