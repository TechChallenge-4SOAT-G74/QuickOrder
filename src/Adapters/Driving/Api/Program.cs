using Microsoft.EntityFrameworkCore;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Adapters.Driving.Api.Configurations;
using QuickOrder.Core.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings")
);
var migrationsAssembly = typeof(ApplicationContext).Assembly.GetName().Name;
var migrationTable = "__IntegradorPlurallMigrationsHistory";
var databaseSettings = builder.Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(databaseSettings.ConnectionString, b =>
    {
        b.MigrationsAssembly(migrationsAssembly);
        b.MigrationsHistoryTable(migrationTable);
    });

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
});



builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.Migrate();
}

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
