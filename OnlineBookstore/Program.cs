using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineBook.Book.DataAccess;
using OnlineBookstore.Book.Application;
using OnlineBookstore.Book.Core;
using OnlineBookstore.Book.DataAccess;
using OnlineBookstore.Report.Application;
using OnlineBookstore.Report.Core;
using OnlineBookstore.Report.DataAccess;
using OnlineBookstore.User.Application;
using OnlineBookStore.User.Core;
using OnlineBookStore.User.DataAccess;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valid JWT bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] {} }
    });
});

//Book MicroService
builder.Services.AddDbContext<BookDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookMicroService.Book"));
    // this connection in appsetting.json
});

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IBookService, BookService>();

//User MicroService
builder.Services.AddDbContext<UserDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookMicroService.User"));
    // this connection in appsetting.json
});
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITokenHandler, OnlineBookStore.User.Core.TokenHandler>();

//User MicroService
builder.Services.AddDbContext<ReportContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBookMicroService.Report"));
    // this connection in appsetting.json
});
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IReportService, ReportService>();

// inject mapper
builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(new[]
    {
    "OnlineBookstore.Book.DataAccess",
    "OnlineBookStore.User.DataAccess"
    });
},typeof(Program).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.UseSerilogRequestLogging();

app.Run();
