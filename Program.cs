using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using ApiSalud.Core.Interfaces;
using ApiSalud.Core.Services;
using ApiSalud.DataAccess;
using ApiSalud.Entities;
using ApiSalud.Repositories;
using ApiSalud.Repositories.Interfaces;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

var configuration = builder.Services.BuildServiceProvider()
    .GetRequiredService<IConfiguration>();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<SaludContext>
    (options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")); });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<SaludContext>()
    .AddDefaultTokenProviders();


// var client = new SecretClient(vaultUri: new Uri("https://saludoskey.vault.azure.net/"), credential: new DefaultAzureCredential());
// KeyVaultSecret secret = client.GetSecret("SaludOsApi");


//var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration[tokene]));

var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

builder.Services.AddTransient<ISendgridMailService, SendGridMailService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "ubaldoramirez.azurewebsites.net",
                     ValidAudience = "ubaldoramirez.azurewebsites.net",
                     IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["VaultUri"])),
                     ClockSkew = TimeSpan.Zero
                 });


builder.Services.AddCors(options =>
{
    var frontEndUrl = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder
            .WithOrigins(frontEndUrl)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.



if (app.Environment.IsDevelopment())
{
 
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();


app.Run();