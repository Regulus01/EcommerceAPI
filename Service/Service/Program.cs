using System.Reflection;
using Infra.CrossCutting.Util.Configuration.Core.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//Servicos
DependencyInjection.Register(builder.Services);

builder.Services.AddControllers();
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