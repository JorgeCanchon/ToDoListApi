using Application;
using Persistence;
using Shared;
using WebApiToDo.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfraestructure(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddApiVersionExtension();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
