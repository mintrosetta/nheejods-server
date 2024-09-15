using Microsoft.EntityFrameworkCore;
using nheejods.Contexts;
using nheejods.UnitOfWorks;
using nheejods.UnitOfWorks.Interfaces;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add database context
builder.Services.AddDbContext<MySQLDbContext>((option) => {
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (connectionString == null || string.IsNullOrEmpty(connectionString.Trim())) throw new Exception("Database connection string not initialize");

    option.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(connectionString), (mysqlOption) => {
        mysqlOption.SchemaBehavior(MySqlSchemaBehavior.Ignore);
    });

    Console.WriteLine("Database connection successfully");
});

// Add services to the container.
builder.Services.AddScoped<IRepoUnitOfWork, RepoUnitOfWork>();
builder.Services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
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

// add middileware

app.MapControllers();
app.Run();