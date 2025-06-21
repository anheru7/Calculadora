using CalculadoraSalarial.Repositories.Interfaces;
using CalculadoraSalarial.Repositories.Logic;

var builder = WebApplication.CreateBuilder(args);

// Forzar a escuchar en el puerto 80 para Docker
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Agrega los servicios de controladores
builder.Services.AddControllers();

// Agrega swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar la dependencia de ICalculadora
builder.Services.AddScoped<ICalculadora, Calculadora>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();