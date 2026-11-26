using BookStore.Data;
using BookStore.DTOs.Author;
using BookStore.MIddlewares;
using BookStore.Repositories.AuthorRepo;
using BookStore.Services.AuthorService;
using BookStore.Validators.AuthorValidators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
//using Npgsql;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;
//using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();

builder.Services.AddDbContext<AppDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    //.EnableSensitiveDataLogging()
);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

// Register validators
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// dotnet ef migrations add init
// dotnet ef database update