using LaboratorioRestApi.Data;
using LaboratorioRestApi.Repositories;
using LaboratorioRestApi.Repositories.Interfaces;
using LaboratorioRestApi.Services;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Adiciona o DbContext com banco InMemory
builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseInMemoryDatabase("BibliotecaDB"));

// Adiciona o Repository
builder.Services.AddScoped<IAutorRepository, AutorRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

// Adiciona o Service
builder.Services.AddScoped<BibliotecaService>();

// Adiciona os serviços MVC/API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Mapeia os controllers
app.MapControllers();

app.Run();
