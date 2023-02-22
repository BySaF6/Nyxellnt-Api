using NyxellntAPI.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NyxellntDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NyxellntApiDb")));
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<NyxellntDb>();
//Evento
builder.Services.AddTransient<EventoServiceInterface, EventoService>();
//Operacion
builder.Services.AddTransient<OperacionServiceInterface, OperacionService>();
//Usuario
builder.Services.AddTransient<UsuarioServiceInterface, UsuarioService>();

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
