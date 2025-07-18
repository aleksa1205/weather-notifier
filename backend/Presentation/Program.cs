using Application.DependencyInjection;
using Carter;
using Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services
    .AddApplication()
    .AddPersistence(builder.Configuration);

builder.Services
    .AddSwaggerGen()
    .AddCarter();

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