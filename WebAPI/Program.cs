using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Model;
using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BookContext>
    (options => options.UseSqlServer
    ("Data Source=DESKTOP-S9GK8EC\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True"));

builder.Services.AddScoped<IBookRepository, BookRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
