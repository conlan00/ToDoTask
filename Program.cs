using Microsoft.EntityFrameworkCore;
using ToDo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString =builder.Configuration.GetConnectionString("DbConnection1");
var serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<DataDbContext>(options => {
    options.UseMySql(connectionString, serverVersion)
     .LogTo(Console.WriteLine, LogLevel.Information)
     .EnableSensitiveDataLogging()
     .EnableDetailedErrors();
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
