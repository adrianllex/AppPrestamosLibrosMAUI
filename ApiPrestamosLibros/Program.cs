using ApiPrestamosLibros.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? Cambia aquí tu cadena de conexión de PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ? Agregar contexto de base de datos PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// ? Agregar controladores
builder.Services.AddControllers();

// ? Agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
