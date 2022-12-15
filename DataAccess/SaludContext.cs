using AlkemyWallet.Core.Helper;
using ApiSalud.DataAccess.Seeds;
using ApiSalud.Entities;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ApiSalud.Core.Helper;

namespace ApiSalud.DataAccess;

public class SaludContext :  IdentityDbContext<ApplicationUser>
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        const string secretConnection = "ConnectionStrings--QueueConnectionString";
        var keyVaultName = "ubaldoramirezapi";
        var kvUri = $"https://{keyVaultName}.vault.azure.net";


        var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
        var secret = client.GetSecretAsync(secretConnection).Result.Value.Value;


        optionsBuilder.UseSqlServer(secret);
    }


    public DbSet<Product>? Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        new ProductSeeder(modelBuilder).SeedProduct();


        modelBuilder.Entity<Product>().ToTable("Product");
        base.OnModelCreating(modelBuilder);
    }
}