using Microsoft.EntityFrameworkCore;
using TuCarbureAPI.EntityLayer;
using TuCarbureAPI.Interfaces;
using TuCarbureAPI.RepositoryLayer;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection

builder.Services.AddScoped<IRepository<Releve>, ReleveRepository>();
builder.Services.AddScoped<IRepository<Carburant>, CarburantRepository>();
builder.Services.AddScoped<IRepository<Station>, StationRepository>();

// Configuration DB

//builder.Services.AddScoped<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDbContext<MySqlConnectionContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

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
