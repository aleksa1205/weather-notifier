using Application;
using Persistence;
using Presentation.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

//connecting layers
builder.Services.AddApplication();
builder.Services.AddPersistence();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEndpoints();
app.Run();