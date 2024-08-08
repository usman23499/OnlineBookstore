using Microsoft.EntityFrameworkCore;
using OnlineBook.Book.DataAccess;
using OnlineBookstore.Application;
using OnlineBookstore.Core;
using OnlineBookstore.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// in inject db context
builder.Services.AddDbContext<BookDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBook"));
    // this connection in appsetting.json
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IBookService, BookService>();


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
