using Examen.Data;
using Examen.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


//Configurar conexion a DB
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API de Tareas",
        Version = "v1.0",
        Description = "Documentacion de API para Examen del segundo Parcial de Programacion Movil"
    });
}
    );

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TareaService>();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.Run();