using BookStore.Data;
using BookStore.MIddlewares;
using BookStore.Repositories.AuthorRepo;
using BookStore.Services.AuthorService;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();

builder.Services.AddDbContext<AppDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging()
);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


// dotnet ef migrations add init
// dotnet ef database update