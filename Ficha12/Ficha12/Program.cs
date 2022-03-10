using Ficha12.Data;
using Ficha12.Models;
using Ficha12.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aplicando dependency injection adicione � lista de servi�os da aplica��o um contexto
// para a base de dados do tipo LibraryContext
builder.Services.AddDbContext<LibraryContext>();
// Aplicando dependency injection adicione � lista de servi�os da aplica��o um servi�o
// com tempo de vida scoped para a base de dados do tipo IBookService com implementa��o BookService
builder.Services.AddScoped<IBookService, BookService>();

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

app.CreateDbIfNotExists();

app.Run();
