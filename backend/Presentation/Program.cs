using Application;
using Carter;
using Persistence;
using Presentation.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

//connecting layers
builder.Services.AddApplication();
builder.Services.AddPersistence();

builder.Services.AddSwaggerGen();
builder.Services.AddCarter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapCarter();
app.Run();