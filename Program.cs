using System.Reflection;
using System.Text.Json.Serialization;
using ApiSalud.Core.Interfaces;
using ApiSalud.Core.Services;
using ApiSalud.DataAccess;
using ApiSalud.Repositories;
using ApiSalud.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alkemy Wallet", Version = "v1" });
        //Locate the XML file being generated by ASP.NET...
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        //... and tell Swagger to use those XML comments.
        // c.IncludeXmlComments(xmlPath);
    }
);
builder.Services.AddDbContext<SaludContext>
    (options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")); });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(o => o
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});
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