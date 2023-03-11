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

builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "frontend",
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
builder.Services.AddMvc().AddMvcOptions(e => e.EnableEndpointRouting = false);

app.UseCors("frontend");

/*
static void configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<NyxellntDb>();
        context.Database.Migrate();
    }
}
*/
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


