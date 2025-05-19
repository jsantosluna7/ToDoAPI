using Microsoft.EntityFrameworkCore;
using ToDoApp.Abstraccion.Repositorios;
using ToDoApp.Abstraccion.Servicios;
using ToDoApp.Implementaciones.Repositorios;
using ToDoApp.Implementaciones.Servicios;
using ToDoApp.Modelos;

var builder = WebApplication.CreateBuilder(args);

//conectar a la base de datos
builder.Services.AddDbContext<DbToDoContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Servicios para el repositorio
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorioToDo, RepositorioToDo>();

//Servicios para el servicio
builder.Services.AddScoped<IServicioUsuarios, ServicioUsuarios>();
builder.Services.AddScoped<IServicioToDo, ServicioToDo>();

//Variables de entorno
DotNetEnv.Env.Load();

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
